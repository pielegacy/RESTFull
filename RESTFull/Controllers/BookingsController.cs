using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController
    {
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            var db = new Db();
            var result = db.Bookings.ToList();
            return result;
        }
    }
}