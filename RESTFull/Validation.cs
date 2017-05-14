using System;
using RESTFull.Models;

namespace RESTFull
{
    ///<summary>
    /// A collection of validation helpers for Models to make up for the
    /// shortcomings of SQLite
    ///</summary>
    public static class ValidationHelpers
    {
        public static bool IsValid(this Booking val) => !String.IsNullOrEmpty(val.BookingName) && val.Date != null;
        // public static bool IsValid(this StoreDetails val)
    }
}