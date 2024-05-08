namespace Library.Web
{
    using AspNetCoreRateLimit;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.Configurations;
    using Infrastructure.Extensions;
    using Infrastructure.Rules;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Logging;
    using Services.Models.EmailSender;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using static WebConstants;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), RootFolderName)));

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<LibraryDbContext>()
                .AddDefaultTokenProviders();

            services.AddOptions();
            services.AddMemoryCache();

            //configure ip rate limiting middle-ware
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            //configure client rate limiting middleware
            services.Configure<ClientRateLimitOptions>(Configuration.GetSection("ClientRateLimiting"));
            services.Configure<ClientRateLimitPolicies>(Configuration.GetSection("ClientRateLimitPolicies"));
            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();

            var opt = new ClientRateLimitOptions();
            ConfigurationBinder.Bind(Configuration.GetSection("ClientRateLimiting"), opt);

            services.AddDomainServices();

            services.AddAutoMapper();

            services.AddRouting(routing => routing.LowercaseUrls = true);

            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("EmailSettings"));

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            //Allows injecting configurations in razor views from json file
            services.Configure<ApplicationConfigurations>(Configuration.GetSection("ApplicationConfigurations"));

            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                options.Filters.Add<RequireHttpsAttribute>();
            })
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
              .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("bg-BG"),
                    new CultureInfo("en-US")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "bg-BG", uiCulture: "bg-BG");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {                
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };

            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            

            //Limits requests
            app.UseIpRateLimiting();
            app.UseClientRateLimiting();

            //localization
            app.UseRequestLocalization();

            var options = new RewriteOptions()
             .AddRedirectToHttps();

            options.Rules.Add(new NonWwwRule());            
            app.UseRewriter(options);

            //migrations
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "Robots",
                    "Robots.txt",
                    new { controller = "Home", action = "Robots" }
                );

                routes.MapRoute(
                    "Sitemap",
                    "sitemap.xml",
                    new { controller = "Home", action = "SiteMap" }
                );

                routes.MapRoute(
                    name: "viewEvent",
                    template: "libraryblog/events/events",
                    defaults: new { area = "LibraryBlog", controller = "Events", action = "Events" });

                routes.MapRoute(
                    name: "editEvent",
                    template: "libraryblog/events/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Events", action = "Edit" });

                routes.MapRoute(
                    name: "deleteEvent",
                    template: "libraryblog/events/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Events", action = "Delete" });

                routes.MapRoute(
                    name: "destroyEvent",
                    template: "libraryblog/events/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Events", action = "Destroy" });

                routes.MapRoute(
                    name: "viewGallery",
                    template: "libraryblog/galleries/galleries",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Galleries" });

                routes.MapRoute(
                    name: "editGallery",
                    template: "libraryblog/galleries/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Edit" });

                routes.MapRoute(
                    name: "deleteGallery",
                    template: "libraryblog/galleries/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Delete" });

                routes.MapRoute(
                    name: "destroyGallery",
                    template: "libraryblog/galleries/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Galleries", action = "Destroy" });

                routes.MapRoute(
                    name: "viewArticle",
                    template: "libraryblog/articles/articles",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Articles" });

                routes.MapRoute(
                    name: "editArticle",
                    template: "libraryblog/articles/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Edit" });

                routes.MapRoute(
                    name: "deleteArticle",
                    template: "libraryblog/articles/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Delete" });

                routes.MapRoute(
                    name: "destroyArticle",
                    template: "libraryblog/articles/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Articles", action = "Destroy" }); 

                routes.MapRoute(
                    name: "viewDepartment",
                    template: "libraryblog/departments/departments",
                    defaults: new { area = "LibraryBlog", controller = "Departments", action = "Departments" });

                routes.MapRoute(
                    name: "editDepartment",
                    template: "libraryblog/departments/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Departments", action = "Edit" });

                routes.MapRoute(
                    name: "deleteDepartment",
                    template: "libraryblog/departments/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Departments", action = "Delete" });

                routes.MapRoute(
                    name: "destroyDepartment",
                    template: "libraryblog/departments/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Departments", action = "Destroy" });

                routes.MapRoute(
                    name: "viewLibServiceType",
                    template: "libraryblog/libservicetypes/libservicetypes",
                    defaults: new { area = "LibraryBlog", controller = "LibServiceTypes", action = "LibServiceTypes" });

                routes.MapRoute(
                    name: "editLibServiceType",
                    template: "libraryblog/libservicetypes/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "LibServiceTypes", action = "Edit" });

                routes.MapRoute(
                    name: "deleteLibServiceType",
                    template: "libraryblog/libservicetypes/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "LibServiceTypes", action = "Delete" });

                routes.MapRoute(
                    name: "destroyLibServiceType",
                    template: "libraryblog/libservicetypes/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "LibServiceTypes", action = "Destroy" });

                routes.MapRoute(
                    name: "editLibServiceDescription",
                    template: "libraryblog/libservicedescriptions/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "LibServiceDescriptions", action = "Edit" });

                routes.MapRoute(
                    name: "deleteLibServiceDescription",
                    template: "libraryblog/libservicedescriptions/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "LibServiceDescriptions", action = "Delete" });

                routes.MapRoute(
                    name: "destroyLibServiceDescription",
                    template: "libraryblog/libservicedescriptions/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "LibServiceDescriptions", action = "Destroy" });

                routes.MapRoute(
                    name: "editEmployee",
                    template: "libraryblog/employees/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Employees", action = "Edit" });

                routes.MapRoute(
                    name: "deleteEmployee",
                    template: "libraryblog/employees/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Employees", action = "Delete" });

                routes.MapRoute(
                    name: "destroyEmployee",
                    template: "libraryblog/employees/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Employees", action = "Destroy" });

                routes.MapRoute(
                   name: "viewWorkSchedule",
                   template: "libraryblog/workschedules/workschedules",
                   defaults: new { area = "LibraryBlog", controller = "WorkSchedules", action = "WorkSchedules" });

                routes.MapRoute(
                    name: "editWorkSchedule",
                    template: "libraryblog/workschedules/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "WorkSchedules", action = "Edit" });

                routes.MapRoute(
                    name: "deleteWorkSchedule",
                    template: "libraryblog/workschedules/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "WorkSchedules", action = "Delete" });

                routes.MapRoute(
                    name: "destroyWorkSchedule",
                    template: "libraryblog/workschedules/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "WorkSchedules", action = "Destroy" });

                routes.MapRoute(
                    name: "viewBooks",
                    template: "libraryblog/books/books",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Books" });

                routes.MapRoute(
                    name: "editBook",
                    template: "libraryblog/books/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Edit" });

                routes.MapRoute(
                    name: "deleteBook",
                    template: "libraryblog/books/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Delete" });

                routes.MapRoute(
                    name: "destroyBook",
                    template: "libraryblog/books/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Books", action = "Destroy" });

                routes.MapRoute(
                    name: "editSubscription",
                    template: "libraryblog/subscriptions/edit/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Subscriptions", action = "Edit" });

                routes.MapRoute(
                    name: "deleteSubscription",
                    template: "libraryblog/subscriptions/delete/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Subscriptions", action = "Delete" });

                routes.MapRoute(
                    name: "destroySubscription",
                    template: "libraryblog/subscriptions/destroy/{id}",
                    defaults: new { area = "LibraryBlog", controller = "Subscriptions", action = "Destroy" });

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}