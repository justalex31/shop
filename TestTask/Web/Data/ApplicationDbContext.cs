using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Web.Helper;

namespace Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>().ToTable(EntitySetName.Catalog);
            modelBuilder.Entity<Product>().ToTable(EntitySetName.Product);
            modelBuilder.Entity<UserRole>().ToTable(EntitySetName.UserRole);
            modelBuilder.Entity<User>().ToTable(EntitySetName.User);
            modelBuilder.Entity<Order>().ToTable(EntitySetName.Order);
            modelBuilder.Entity<Rate>().ToTable(EntitySetName.Rate);

            base.OnModelCreating(modelBuilder);
        }
    }
}
