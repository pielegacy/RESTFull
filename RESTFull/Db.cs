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
        public DbSet<MenuItem> Combos { get; set; }
        public DbSet<MenuItem>  ComboItems{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Main.db");
        }
    }
}