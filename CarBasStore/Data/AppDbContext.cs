using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBasStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CarBasStore.Models;

namespace CarBasStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand_CarProduct>().HasKey(am => new
            {
               
                am.BrandId,
                am.CarProductId,
            });

            modelBuilder.Entity<Brand_CarProduct>().HasOne(m => m.CarProduct).WithMany(am => am.Brand_CarProducts).HasForeignKey(m => m.CarProductId);
            modelBuilder.Entity<Brand_CarProduct>().HasOne(m => m.Brand).WithMany(am => am.Brand_CarProducts).HasForeignKey(m => m.BrandId);


            base.OnModelCreating(modelBuilder);
        }

 
        public DbSet<CarProduct> CarProducts { get; set; }
        public DbSet<Brand_CarProduct> Brand_CarProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}

