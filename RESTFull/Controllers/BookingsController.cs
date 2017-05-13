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

        [HttpGet("{id}")]
        public Booking Get(int id)
        {
            using (var db = new Db())
            {
                return db.Bookings.FirstOrDefault(b => b.Id == id);
            }
        }

        [HttpPost]
        public async void Post([FromBody]Booking value)
        {
            using (var db = new Db())
            {
                if (value.IsValid())
                {
                    await db.Bookings.AddAsync(value);
                    await db.SaveChangesAsync();
                }
            }
        }

        // [HttpPutAttribute]

    }
}