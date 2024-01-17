using Microsoft.EntityFrameworkCore;
using ProductsMvc.Data.Entities;
using ProductsMvc.Models;

namespace ProductsMvc.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override int SaveChanges()
        {
            foreach (var entity in this.ChangeTracker.Entries())
            {
                ((BaseEntity)entity.Entity).ModifiedTime = DateTime.Now;
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreationTime = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
