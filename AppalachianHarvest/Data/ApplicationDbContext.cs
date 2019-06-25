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


        }
    }
}
