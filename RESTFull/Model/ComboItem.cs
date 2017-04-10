using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFull.Models
{
    ///<summary>
    /// A middle table to connect combo and menuitem
    ///</summary>
    ///<remarks>
    /// 
    ///</remarks>
    public class ComboItem
    {
        [Key, ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        [Key, ForeignKey("Combo")]
        public int ComboId { get; set; }

        public virtual Combo Combo { get; set; }

    }
}