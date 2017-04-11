using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
    ///<summary>
    /// Shorthand class for creating a combo with items in it
    /// This class will require manual validation using the IsValid property
    /// attached to it.
    ///</summary>
    public class ComboShortHand
    {
        public string ComboDescription { get; set; }

        public decimal? ComboPrice { get; set; }
        public List<int> ItemIds { get; set; }
        [JsonIgnore]
        public bool IsValid => ComboDescription != null && ComboPrice != null && ItemIds != null && ItemIds.Count > 0;
        [JsonIgnoreAttribute]
        public Combo Combo
        {
            get
            {
                {
                    if (IsValid)
                    {
                        return new Combo()
                        {
                            ComboDescription = ComboDescription,
                            ComboPrice = ComboPrice
                        };
                    }
                    else
                    {
                        return null;
                    }
                };
            }
        }

    }
}