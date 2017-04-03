using System;
using System.ComponentModel.DataAnnotations;

namespace RESTFull.Models
{
    public enum MenuItemType
    {
        Entree,
        Main,
        Dessert,
        Beverage,
        Side
    }
    ///<summary>
    /// A meal that's available on the menu
    ///</summary>
    public class MenuItem
    {
        [KeyAttribute]
        public int Id { get; set; }

        [RequiredAttribute]
        public string Name { get; set; }

        [RequiredAttribute]
        public decimal Price { get; set; }

        [RequiredAttribute]
        public MenuItemType Type { get; set; }

        public int Calories { get; set; }

    }
}