﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PEADotNetTraining.Models;
namespace PEADotNetTraining.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseCollation("THAI_CI_AS");
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    
}
