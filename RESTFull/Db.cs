using System;
using System.Linq;
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
        public DbSet<ComboItem> ComboItems { get; set; }
        public DbSet<StoreDetails> StoreDetails { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Main.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComboItem>()
                .HasKey(c => new { c.MenuItemId, c.ComboId });
        }
    }
    ///<summary>
    /// Use relationship to store functions which are used by the
    /// controllers to create relationships between the models
    ///<summary>
    public static class Relationship
    {
        ///<summary>
        /// Populate a combos menu items
        ///</summary>
        public static void ComboToMenuItems(this Combo obj)
        {
            using (var db = new Db())
            {
                var menuIds = db.ComboItems.Where(c => c.ComboId == obj.ComboId).Select(i => i.MenuItemId);
                obj.Items = db.MenuItems.Where(m => menuIds.Contains(m.Id)).ToList();
            }
        }
    }
}