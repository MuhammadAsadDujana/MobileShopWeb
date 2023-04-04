using Microsoft.EntityFrameworkCore;
using MobileShopWeb.Models;
using MobileShopWeb.ViewModel;
using System;

namespace MobileShopWeb.Context
{
    public class Contextdb : DbContext
    {
        public Contextdb(DbContextOptions<Contextdb> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }


        public virtual DbSet<BrandTotalProductsVM> BrandTotalProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandTotalProductsVM>().HasNoKey().ToView(null); //Not included in SQL server just for stored procedure resultset
            modelBuilder.Entity<ProductColor>().HasKey(sc => new { sc.ProductId, sc.ColorId }); //Make Composite key in the middle table (ProductColor)
            modelBuilder.Entity<ProductColor>().HasOne(p => p.Products).WithMany(p => p.ProductColors).HasForeignKey(p => p.ProductId); //delete all related records from ProductColor when Product is deleted
            modelBuilder.Entity<ProductColor>().HasOne(p => p.Colors).WithMany(p => p.ProductColors).HasForeignKey(p => p.ColorId); //delete all related records from ProductColor when Color is deleted

            base.OnModelCreating(modelBuilder);
        }

    }


}
