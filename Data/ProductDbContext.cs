﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using React_ASPNETCore.Models;
namespace React_ASPNETCore.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) 
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
