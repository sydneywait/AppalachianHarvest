using System;
using System.Collections.Generic;
using System.Text;
using AppalachianHarvest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppalachianHarvest.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


    }
}
}
