using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KashiHomeFood.Models;
using Microsoft.EntityFrameworkCore;

namespace KashiHomeFood.Data
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }

        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            :base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodMenu>()
                .HasKey(c => new { c.FoodID, c.MenuID });
        }
    }
}
