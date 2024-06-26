﻿namespace Library.Web.Infrastructure.Extensions
{
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Creates Database Migration, roles and roots an Admin user.
        /// </summary>

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<LibraryDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var roleNameAdmin = WebConstants.AdministratorRole;
                        var roleNameLibrarianAuthor = WebConstants.LibrarianAuthorRole;

                        var roles = new[]
                        {
                            roleNameAdmin,
                            roleNameLibrarianAuthor
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@mysite.com";
                        var username = "admin@mysite.com";
                        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = username,
                                UserFullName = roleNameAdmin,
                                UserAge = 27,
                                EmailConfirmed = true
                            };

                            await userManager.CreateAsync(adminUser, "admin12");

                            foreach (var role in roles)
                            {
                                await userManager.AddToRoleAsync(adminUser, role);
                            }
                        }
                    })
                    .Wait();
            }

            return app;
        }
    }
}