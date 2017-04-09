using System.ComponentModel.DataAnnotations;

namespace RESTFull.Models
{
    ///<summary>
    /// Discounts are applied to single items with a percentage off
    ///</summary>
    ///<remarks>
    /// For "multi-buy" savings (eg a happy meal) refer to Combos
    ///</remarks>
    public class Discount
    {
        [KeyAttribute]
        public int Id { get; set; }

        [RequiredAttribute]
        public string Description { get; set; }
        [RequiredAttribute]
        public decimal DiscountPercentage { get; set; }
    }
}