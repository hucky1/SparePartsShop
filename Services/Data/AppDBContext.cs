using Microsoft.EntityFrameworkCore;
using SparePartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Data
{
    public class AppDBContext : DbContext
    {
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ShopCartItem> ShopCartItems{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           // Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Brand)
                .WithMany(t => t.Products)
                .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.CategoryId);



        }
        public DbSet<SparePartsShop.Models.AdminLogin> AdminLogin { get; set; }
    }
}   
