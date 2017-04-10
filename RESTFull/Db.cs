using System;
using Microsoft.EntityFrameworkCore;
using RESTFull.Models;

namespace RESTFull
{
    ///<summary>
    /// The class used for accessing the food Database
    ///</summary>
    public class Db : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboItem> ComboItems{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Main.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComboItem>()
            .HasKey(c => new {c.MenuItemId, c.ComboId});
    }
    }
}