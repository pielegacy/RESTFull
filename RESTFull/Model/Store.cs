using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFull.Models
{
    ///<summary>
    /// Store is used to model the details of an establishment
    ///</summary>
    ///<remark>
    /// In many cases, only one store will be used in a database
    ///</remark>
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Proprietor { get; set; }

        public string ABN { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string AddressStreet { get; set; }

        public string AddressSuburb { get; set; }

        public string AddressCity { get; set; }

        public string AddressState { get; set; }

        public string AddressCountry { get; set; }
        
        public string AddressPostCode { get; set; }
    }
}