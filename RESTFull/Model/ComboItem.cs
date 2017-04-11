using System.ComponentModel.DataAnnotations;
namespace RESTFull.Models
{
    ///<summary>
    /// A middle table to connect combo and menuitem
    ///</summary>
    ///<remarks>
    ///     Removed the virtual combo and menuitem as they were going to create a recurring
    ///         json block
    ///</remarks>
    public class ComboItem
    {
        [Key]
        public int MenuItemId { get; set; }

        // public virtual MenuItem MenuItem { get; set; }

        [Key]
        public int ComboId { get; set; }
        
        // public virtual Combo Combo { get; set; }

    }
}