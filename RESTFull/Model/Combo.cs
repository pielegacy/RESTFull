using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFull.Models
{
    ///<summary>
    /// Combo for menu item and also include additional something for single item
    ///</summary>
    ///<remarks>
    /// For single item only, it may be changed into new class for it
    ///</remarks>
    public class Combo
    {
        [KeyAttribute]
        public int ComboId { get; set; }

        [RequiredAttribute]
        public string ComboDescription { get; set; }

        public decimal? ComboPrice { get; set; }

        [NotMappedAttribute]
        public List<MenuItem> Items = new List<MenuItem>();
    }
}