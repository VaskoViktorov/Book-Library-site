namespace Library.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class LibraryDbContext : IdentityDbContext<User>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<DepartmentStructure> DepartmentStructures { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LibServiceType> LibServiceTypes { get; set; }

        public DbSet<LibServiceDescription> LibServiceDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Article>()
                .HasOne(a => a.Gallery)
                .WithOne(u => u.Article)
                .HasForeignKey<Gallery>(b => b.ArticleId);

            builder
                .Entity<Gallery>()
                .HasOne(a => a.Article)
                .WithOne(u => u.Gallery)
                .HasForeignKey<Article>(b => b.GalleryId);

            builder
                .Entity<Image>()
                .HasOne(a => a.Gallery)
                .WithMany(u => u.Images)
                .HasForeignKey(a => a.GalleryId);

            builder
                .Entity<Employee>()
                .HasOne(a => a.DepartmentStructure)
                .WithMany(u => u.Employees)
                .HasForeignKey(a => a.DepartmentStructureId);

            builder
               .Entity<LibServiceDescription>()
               .HasOne(a => a.LibServiceType)
               .WithMany(u => u.LibServiceDescriptions)
               .HasForeignKey(a => a.LibServiceTypeId);

            base.OnModelCreating(builder);
        }
    }
}