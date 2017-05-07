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
        [Required]
        public string TagName { get; set; }
        public string MenuName { get; set; }
    }
}