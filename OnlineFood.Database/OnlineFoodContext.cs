using Microsoft.EntityFrameworkCore;
using OnlineFood.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineFood.Database
{
    public class OnlineFoodContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer($"Server=onlinefood.cfskozdo8a8f.ap-south-1.rds.amazonaws.com;Database=OnlineFood;User Id=admin;Password=$Admin#1") ;
            base.OnConfiguring(optionsBuilder);

        }

    }
}
