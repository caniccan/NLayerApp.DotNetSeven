using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }

                    }
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate= DateTime.Now;
                                break;
                            }
                            case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x=>x.CreatedDate).IsModified= false;
                                entityReference.UpdatedDate= DateTime.Now; 
                                break;
                            }

                    }
                }
            }



            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // reflection ile tüm assembly'leri bulup değişiklikleri uyguluyor. 


            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Red",
                Height = 100,
                Width = 200,
                ProductId = 1,
            },
            new ProductFeature()                                   // bu şekilde de eklenebilir fakat Seeds içerisinde olmasını tercih ediyoruz.
            {
                Id = 2,
                Color = "Blue",
                Height = 300,
                Width = 300,
                ProductId = 2,
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
