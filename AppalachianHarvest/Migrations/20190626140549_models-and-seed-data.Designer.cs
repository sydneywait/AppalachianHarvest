﻿// <auto-generated />
using System;
using AppalachianHarvest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppalachianHarvest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190626140549_models-and-seed-data")]
    partial class modelsandseeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppalachianHarvest.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("PickupDate");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            OrderDate = new DateTime(2019, 6, 26, 10, 5, 48, 894, DateTimeKind.Local).AddTicks(9734),
                            PickupDate = new DateTime(2019, 6, 27, 10, 5, 48, 895, DateTimeKind.Local).AddTicks(768)
                        });
                });

            modelBuilder.Entity("AppalachianHarvest.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");

                    b.HasData(
                        new
                        {
                            OrderProductId = 1,
                            OrderId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            OrderProductId = 2,
                            OrderId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            OrderProductId = 3,
                            OrderId = 1,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("AppalachianHarvest.Models.Producer", b =>
                {
                    b.Property<int>("ProducerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("BusinessName")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<byte[]>("ProducerImage");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<int>("ZipCode");

                    b.HasKey("ProducerId");

                    b.ToTable("Producer");

                    b.HasData(
                        new
                        {
                            ProducerId = 1,
                            Address = "123 Prairie Lane",
                            BusinessName = "Golden Hills Farms",
                            City = "Ona",
                            Email = "goldenhills@farm.com",
                            FirstName = "Jimmy",
                            IsActive = true,
                            LastName = "Smith",
                            Phone = "304-300-0123",
                            State = "WV",
                            ZipCode = 25545
                        },
                        new
                        {
                            ProducerId = 2,
                            Address = "111 Shocker Place",
                            BusinessName = "Lightning Rod",
                            City = "Culloden",
                            Email = "lightning@farm.com",
                            FirstName = "Sandra",
                            IsActive = true,
                            LastName = "Dee",
                            Phone = "304-300-2546",
                            State = "WV",
                            ZipCode = 25546
                        });
                });

            modelBuilder.Entity("AppalachianHarvest.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Added")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<byte[]>("Image");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsOrganic");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<double>("Price");

                    b.Property<int>("ProducerId");

                    b.Property<int>("ProductTypeId");

                    b.Property<int>("Quantity");

                    b.Property<int>("ShelfId");

                    b.HasKey("ProductId");

                    b.HasIndex("ProducerId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("ShelfId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Added = new DateTime(2019, 6, 26, 10, 5, 48, 893, DateTimeKind.Local).AddTicks(1836),
                            IsActive = true,
                            IsOrganic = true,
                            Name = "Tomatoes",
                            Price = 1.99,
                            ProducerId = 1,
                            ProductTypeId = 1,
                            Quantity = 5,
                            ShelfId = 4
                        },
                        new
                        {
                            ProductId = 2,
                            Added = new DateTime(2019, 6, 26, 10, 5, 48, 894, DateTimeKind.Local).AddTicks(8015),
                            IsActive = true,
                            IsOrganic = true,
                            Name = "Zucchini",
                            Price = 1.99,
                            ProducerId = 1,
                            ProductTypeId = 2,
                            Quantity = 12,
                            ShelfId = 4
                        },
                        new
                        {
                            ProductId = 3,
                            Added = new DateTime(2019, 6, 26, 10, 5, 48, 894, DateTimeKind.Local).AddTicks(8029),
                            IsActive = true,
                            IsOrganic = true,
                            Name = "Lettuce",
                            Price = 1.99,
                            ProducerId = 1,
                            ProductTypeId = 3,
                            Quantity = 5,
                            ShelfId = 4
                        },
                        new
                        {
                            ProductId = 4,
                            Added = new DateTime(2019, 6, 26, 10, 5, 48, 894, DateTimeKind.Local).AddTicks(8033),
                            IsActive = true,
                            IsOrganic = true,
                            Name = "Lavender Soap",
                            Price = 3.9900000000000002,
                            ProducerId = 2,
                            ProductTypeId = 8,
                            Quantity = 12,
                            ShelfId = 3
                        },
                        new
                        {
                            ProductId = 5,
                            Added = new DateTime(2019, 6, 26, 10, 5, 48, 894, DateTimeKind.Local).AddTicks(8036),
                            IsActive = true,
                            IsOrganic = false,
                            Name = "Knit Scarf",
                            Price = 21.989999999999998,
                            ProducerId = 2,
                            ProductTypeId = 9,
                            Quantity = 1,
                            ShelfId = 3
                        });
                });

            modelBuilder.Entity("AppalachianHarvest.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("TimeToExpire")
                        .IsRequired();

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            ProductTypeId = 1,
                            Description = "Fruit",
                            TimeToExpire = 4
                        },
                        new
                        {
                            ProductTypeId = 2,
                            Description = "Vegetable",
                            TimeToExpire = 5
                        },
                        new
                        {
                            ProductTypeId = 3,
                            Description = "Leafy Green",
                            TimeToExpire = 4
                        },
                        new
                        {
                            ProductTypeId = 4,
                            Description = "Canned Good",
                            TimeToExpire = 180
                        },
                        new
                        {
                            ProductTypeId = 5,
                            Description = "Baked Good",
                            TimeToExpire = 3
                        },
                        new
                        {
                            ProductTypeId = 6,
                            Description = "Meat",
                            TimeToExpire = 7
                        },
                        new
                        {
                            ProductTypeId = 7,
                            Description = "Dairy",
                            TimeToExpire = 7
                        },
                        new
                        {
                            ProductTypeId = 8,
                            Description = "Beauty",
                            TimeToExpire = 90
                        },
                        new
                        {
                            ProductTypeId = 9,
                            Description = "Textiles",
                            TimeToExpire = 365
                        });
                });

            modelBuilder.Entity("AppalachianHarvest.Models.Shelf", b =>
                {
                    b.Property<int>("ShelfId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("ShelfId");

                    b.ToTable("Shelf");

                    b.HasData(
                        new
                        {
                            ShelfId = 1,
                            Description = "Freezer"
                        },
                        new
                        {
                            ShelfId = 2,
                            Description = "Cooler"
                        },
                        new
                        {
                            ShelfId = 3,
                            Description = "Center Display"
                        },
                        new
                        {
                            ShelfId = 4,
                            Description = "Produce"
                        },
                        new
                        {
                            ShelfId = 5,
                            Description = "Aisle Shelving"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AppalachianHarvest.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsCustomer");

                    b.Property<bool>("IsEmployee");

                    b.Property<bool>("IsSupervisor");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<byte[]>("ProfilePicture");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1bd98d8e-6dd9-4032-982c-cad11b71c032",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFxl6BrvIAyO5DVydGJtu2rdX9lZs90IhVI8VDGtqP/NrFanmlhWM6IawblNknlg9Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com",
                            FirstName = "Admin",
                            IsCustomer = true,
                            IsEmployee = true,
                            IsSupervisor = true,
                            LastName = "Person"
                        });
                });

            modelBuilder.Entity("AppalachianHarvest.Models.Order", b =>
                {
                    b.HasOne("AppalachianHarvest.Models.ApplicationUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppalachianHarvest.Models.OrderProduct", b =>
                {
                    b.HasOne("AppalachianHarvest.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppalachianHarvest.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppalachianHarvest.Models.Product", b =>
                {
                    b.HasOne("AppalachianHarvest.Models.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppalachianHarvest.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppalachianHarvest.Models.Shelf", "Shelf")
                        .WithMany()
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
