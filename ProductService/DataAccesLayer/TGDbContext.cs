using ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductService.DataAccesLayer
{
    /// <summary>
    /// A database session we use to query or add entities
    /// </summary>
    public class TGDbContext : DbContext
    {
        public TGDbContext(DbContextOptions<TGDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeds
            modelBuilder.Entity<Category>()
          .HasData(
           new Category { Id = 1, Name = "Oyun Bilgisayarları" },
           new Category { Id = 2, Name = "İş Bilgisayarları " });


            modelBuilder.Entity<Product>()
             .HasData(
              new Product { Id = 1, Name = "Tulpar T7 V22.2 17,3 Gaming Laptop", CategoryId = 1},
              new Product { Id = 2, Name = "Tulpar T7 V25.1.2 17,3 Gaming Laptop", CategoryId = 1 },
              new Product { Id = 3, Name = "Casper Excalibur G770.1140-8EL0T-B", CategoryId = 1 },
              new Product { Id = 4, Name = "Asus ROG Strix G513IE-HN065", CategoryId = 1 },
              new Product { Id = 5, Name = "MSI Katana GF76 11UE-414TR ", CategoryId = 1 },
              new Product { Id = 6, Name = "MSI Bravo 15 B5DD-209XTR", CategoryId = 1 },
              new Product { Id = 7, Name = "Apple MacBook Air M1", CategoryId = 2 },
              new Product { Id = 8, Name = "Apple MacBook M1 Pro", CategoryId = 2 },
              new Product { Id = 9, Name = "Apple MacBook Pro M2", CategoryId = 2 },
              new Product { Id = 10, Name = "Apple MacBook Air M2 ", CategoryId = 2 },
              new Product { Id = 11, Name = "Apple MacBook Pro", CategoryId = 2 },
              new Product { Id = 12, Name = "Asus Zenbook Pro", CategoryId = 2 },
              new Product { Id = 13, Name = "Dell M7760 TKNM7760RKS55M09 W-11955M", CategoryId = 2 });

        }
    }
}
