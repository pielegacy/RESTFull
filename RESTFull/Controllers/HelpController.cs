using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    ///<summary>
    /// The Help Controller will be used to return example payloads for the system
    ///</summary>
    [Route("api/[controller]")]
    public class HelpController : Controller
    {
        const string HELP_MESSAGE = "Append the name of the object you are trying to the end of the Help endpoint and you will receive an example output";
        [HttpGet]
        public Dictionary<string, string> Get()
        {
            return new Dictionary<string, string>() { ["How To Use"] = HELP_MESSAGE };
        }
        // GET /api/Help
        [HttpGet("{name}")]
        public object Get(string name)
        {
            switch (name.ToLower())
            {
                case "menuitem":
                case "menuitems":
                case "item":
                case "food":
                    return new MenuItem()
                    {
                        Id = 99,
                        Name = "Example Menu Item Name*",
                        Price = 99.99M,
                        Type = MenuItemType.Main,
                        Calories = 99,
                        DiscountId = 1,
                        Discount = new Discount() { Id = 1, Description = "Example Discount", DiscountPercentage = 50 },
                    };
                case "discount":
                case "discounts":
                    return new Discount() { Id = 1, Description = "Example Discount", DiscountPercentage = 50 };
                case "combo":
                case "combos":
                    return new Combo()
                    {
                        ComboId = 1,
                        ComboDescription = "Example Combo",
                        ComboPrice = 4.20m,
                        Items = new List<MenuItem>() {new MenuItem()
                    {
                        Id = 99,
                        Name = "Example Menu Item Name*",
                        Price = 99.99M,
                        Type = MenuItemType.Main,
                        Calories = 99,
                        DiscountId = 1,
                        Discount = new Discount() { Id = 1, Description = "Example Discount", DiscountPercentage = 50 },
                    },
                    new MenuItem()
                    {
                        Id = 99,
                        Name = "Example Menu Item Name* 2",
                        Price = 99.99M,
                        Type = MenuItemType.Beverage,
                        Calories = 82
                    } }
                    };
                default:
                    return new Dictionary<string, string>() { ["How To Use"] = HELP_MESSAGE };
            }
        }
    }
}
