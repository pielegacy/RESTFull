using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController: Controller
    {
        // GET api/Bookings/
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            var db = new Db();
            var result = db.Bookings.ToList();
            return result;
        }
        // GET api/Bookings/{id}
        [HttpGet("{id}")]
        public Booking Get(int id)
        {
            using (var db = new Db())
            {
                return db.Bookings.FirstOrDefault(b => b.Id == id);
            }
        }
        // POST api/Bookings/
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
        // PUT api/Bookings/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Booking value)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Db())
                {
                    Booking res = db.Bookings.FirstOrDefault(b => b.Id == id);
                    db.Bookings.Remove(res);
                    if (res != null)
                    {
                        res = value;
                        await db.Bookings.AddAsync(res);
                        await db.SaveChangesAsync();
                        return new CreatedAtRouteResult("Bookings", value.Id);
                    }
                    else
                        return new StatusCodeResult(400);
                }
            }
            else
                return new StatusCodeResult(400);
        }
        // DELETE api/Bookings/{id}
        [HttpDelete("{id}")]
        public async Task<Booking> Delete(int id)
        {
            using (var db = new Db())
            {
                var removed = db.Bookings.FirstOrDefault(b => b.Id == id);
                db.Bookings.Remove(removed);
                await db.SaveChangesAsync();
                return removed;
            }
        }

    }
}