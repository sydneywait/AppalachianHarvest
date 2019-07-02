using AppalachianHarvest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppalachianHarvest.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Shelf> Shelves { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Person",
                UserName = "admin@admin.com",
                IsCustomer = true,
                IsEmployee = true,
                IsSupervisor = true,
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

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
                   Description = "Fruit",
                   TimeToExpire = 4
               },
               new ProductType()
               {
                   ProductTypeId = 2,
                   Description = "Vegetable",
                   TimeToExpire = 5
               },
               new ProductType()
               {
                   ProductTypeId = 3,
                   Description = "Leafy Green",
                   TimeToExpire = 4
               },
               new ProductType()
               {
                   ProductTypeId = 4,
                   Description = "Canned Good",
                   TimeToExpire = 180
               },
               new ProductType()
               {
                   ProductTypeId = 5,
                   Description = "Baked Good",
                   TimeToExpire = 3
               },
               new ProductType()
               {
                   ProductTypeId = 6,
                   Description = "Meat",
                   TimeToExpire = 7
               },
               new ProductType()
               {
                   ProductTypeId = 7,
                   Description = "Dairy",
                   TimeToExpire = 7
               },
               new ProductType()
               {
                   ProductTypeId = 8,
                   Description = "Beauty",
                   TimeToExpire = 90
               },
                new ProductType()
                {
                    ProductTypeId = 9,
                    Description = "Textiles",
                    TimeToExpire = 365
                }
           );

            modelBuilder.Entity<Shelf>().HasData(
              new Shelf()
              {
                  ShelfId = 1,
                  Description = "Freezer"
              },
              new Shelf()
              {
                  ShelfId = 2,
                  Description = "Cooler"
              },
              new Shelf()
              {
                  ShelfId = 3,
                  Description = "Center Display"
              },
              new Shelf()
              {
                  ShelfId = 4,
                  Description = "Produce"
              },
              new Shelf()
              {
                  ShelfId = 5,
                  Description = "Aisle Shelving"
              });

            modelBuilder.Entity<Producer>().HasData(
                new Producer()
                {
                    ProducerId = 1,

                    FirstName = "Jimmy",
                    LastName = "Smith",
                    BusinessName = "Golden Hills Farms",
                    Phone = "304-300-0123",
                    Email = "goldenhills@farm.com",
                    Address = "123 Prairie Lane",
                    City = "Ona",
                    State = "WV",
                    ZipCode = 25545,
                    ProducerImage = null,
                    IsActive = true

                },
                  new Producer()
                  {
                      ProducerId = 2,
                      FirstName = "Sandra",
                      LastName = "Dee",
                      BusinessName = "Lightning Rod",
                      Phone = "304-300-2546",
                      Email = "lightning@farm.com",
                      Address = "111 Shocker Place",
                      City = "Culloden",
                      State = "WV",
                      ZipCode = 25546,
                      ProducerImage = null,
                      IsActive = true

                  }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    Name = "Tomatoes",
                    ProducerId = 1,
                    ProductTypeId = 1,
                    ShelfId = 4,
                    Quantity = 5,
                    Price = 1.99,
                    Image = null,
                    IsOrganic = true,
                    IsActive = true,
                    Added = DateTime.Now

                },
                new Product()

                {
                    ProductId = 2,
                    Name = "Zucchini",
                    ProducerId = 1,
                    ProductTypeId = 2,
                    ShelfId = 4,
                    Quantity = 12,
                    Price = 1.99,
                    Image = null,
                    IsOrganic = true,
                    IsActive = true,
                    Added = DateTime.Now

                },
                new Product()
                {
                    ProductId = 3,
                    Name = "Lettuce",
                    ProducerId = 1,
                    ProductTypeId = 3,
                    ShelfId = 4,
                    Quantity = 5,
                    Price = 1.99,
                    Image = null,
                    IsOrganic = true,
                    IsActive = true,
                    Added = DateTime.Now

                },
                 new Product()
                 {
                     ProductId = 4,
                     Name = "Lavender Soap",
                     ProducerId = 2,
                     ProductTypeId = 8,
                     ShelfId = 3,
                     Quantity = 12,
                     Price = 3.99,
                     Image = null,
                     IsOrganic = true,
                     IsActive = true,
                     Added = DateTime.Now

                 },
                 new Product()
                 {
                     ProductId = 5,
                     Name = "Knit Scarf",
                     ProducerId = 2,
                     ProductTypeId = 9,
                     ShelfId = 3,
                     Quantity = 1,
                     Price = 21.99,
                     Image = null,
                     IsOrganic = false,
                     IsActive = true,
                     Added = DateTime.Now

                 });

            modelBuilder.Entity<Order>().HasData(
               new Order()
               {
                   OrderId = 1,
                   OrderDate = DateTime.Now,
                   CustomerId = user.Id,
                   PickupDate = DateTime.Now + new TimeSpan(24,0,0)
               }
           );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 1,
                    OrderId = 1,
                    ProductId = 1
                }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 2,
                    OrderId = 1,
                    ProductId = 2
                }
            );
            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 3,
                    OrderId = 1,
                    ProductId = 3
                }
            );

        }

    }
}
