using System;
using Microsoft.EntityFrameworkCore;

namespace RESTFull
{
    ///<summary>
    /// The class used for accessing the food Database
    ///</summary>
    public class Db : DbContext
    {
        DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Main.db");
        }
    }
}