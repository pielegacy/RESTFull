using System;
using System.ComponentModel.DataAnnotations;

namespace RESTFull.Models
{
    ///<summary>
    /// Bookings encompass the table logic of the restaurant.
    ///</summary>
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        ///<summary>
        /// The name which the booking is made under
        ///</summary>
        public string BookingName { get; set; }
        ///<summary>
        /// The date which the booking is made under
        ///</summary>
        public DateTime Date { get; set; }
    }
}