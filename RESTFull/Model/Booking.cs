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
        /// The name of the Store which the booking relates to.
        ///</summary>
        public string StoreName { get; set; }
        ///<summary>
        /// The table number
        ///</summary>
        public int Number { get; set; }
        ///<summary>
        /// The capacity of the table, used to figure out if available is valid
        ///</summary>
        public int TableCapacity { get; set; }
        ///<summary>
        /// The amount that's been booked
        ///</summary>
        ///<remarks>
        /// Might change name of this, I don't like the structure
        ///</remarks>
        public int Available { get; set; }
    }
}