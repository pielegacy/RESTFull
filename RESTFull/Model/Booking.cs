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
        [Required]
        public string BookingName { get; set; }
        ///<summary>
        /// The date which the booking is made under
        ///</summary>
        [Required]
        public DateTime Date { get; set; }
        ///<summary>
        /// The table number that has been booked
        ///</summary>
        [Required]
        public int Number { get; set; }
        ///<summary>
        /// The people at the table booking
        ///</summary>
        [Required]
        public int People { get; set; }
    }
}