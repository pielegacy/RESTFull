using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RESTFull.Models
{
    ///<summary>
    /// Tags are used to link food items with a certain "food based category"
    ///</summary>
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TagName { get; set; }
        public string MenuName { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Tag) && (obj as Tag).MenuName.Trim() == MenuName.Trim();
        }

        // override object.GetHashCode
        public override int GetHashCode() => (TagName + MenuName).GetHashCode();
    }
}