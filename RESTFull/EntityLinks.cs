using System;
using System.Linq;
using RESTFull.Models;

namespace RESTFull
{
    ///<summary>
    /// EntityLinks provides code for linking entities based on foreign keys and such
    ///</summary>
    ///<remarks>
    /// These methods only exist to facilitate the lack of foreign key filling with SQLite
    ///</remarks>
    public static class EntityLinks
    {
        ///<summary>
        /// Populate a MenuItem's discount, tags and combos
        ///</summary>
        ///<param name="db">
        /// A Database connection to use
        ///</summary>
        public static void Link(this MenuItem obj, Db db)
        {
            obj.Discount = obj.DiscountId.HasValue && db.Discounts.Count() > 0 ? db.Discounts.FirstOrDefault(d => d.Id == obj.DiscountId) : null;
            obj.Tags = db.Tags.Where(t => t.MenuName == obj.Name).ToList();
        }
    }
}