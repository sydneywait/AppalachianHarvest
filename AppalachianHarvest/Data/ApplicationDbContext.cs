using System;
using System.Collections.Generic;
using System.Text;
using AppalachianHarvest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppalachianHarvest.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ApplicationUser user = new ApplicationUser
            //{
            //    FirstName = "Admin",
            //    LastName = "Person",
            //    UserName = "admin@admin.com",
            //    IsCustomer = true,
            //    IsEmployee = true,
            //    IsSupervisor = true,
            //    NormalizedUserName = "ADMIN@ADMIN.COM",
            //    Email = "admin@admin.com",
            //    NormalizedEmail = "ADMIN@ADMIN.COM",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
            //    Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            //};
            //var passwordHash = new PasswordHasher<ApplicationUser>();
            //user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            //modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Order>()
                .Property(b => b.OrderDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
             .Property(b => b.Added)
             .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ProductType>().HasData(
               new ProductType()
               {
                   ProductTypeId = 1,
                   Description = "Fruit"
               },
               new ProductType()
               {
                   ProductTypeId = 2,
                   Description= "Vegetable"
               },
               new ProductType()
               {
                   ProductTypeId = 3,
                   Description= "Leafy Green"
               },
               new ProductType()
               {
                   ProductTypeId = 4,
                   Description= "Canned Good"
               },
               new ProductType()
               {
                   ProductTypeId = 5,
                   Description= "Baked Good"
               },
               new ProductType()
               {
                   ProductTypeId = 6,
                   Description= "Meat"
               },
               new ProductType()
               {
                   ProductTypeId = 7,
                   Description= "Dairy-Fresh"
               },
               new ProductType()
               {
                   ProductTypeId = 8,
                   Description= "Dairy-Frozen"
               },
               new ProductType()
               {
                   ProductTypeId = 9,
                   Description= "Beauty"
               },
               new ProductType()
               {
                   ProductTypeId = 10,
                   Description= "Soap"
               }
           );


        }
    }
}
