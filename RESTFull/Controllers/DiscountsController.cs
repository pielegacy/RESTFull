using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    [Route("api/[controller]")]
    public class DiscountsController : Controller
    {
        // GET api/Discounts
        [HttpGet]
        public List<Discount> Get()
        {
            // Use the database object
            var db = new Db();
            var result = db.Discounts.ToList();
            return result;
        }

        // GET api/Discounts/5
        [HttpGet("{id}")]
        public Discount Get(int id)
        {
            // Use the database object
            using (var db = new Db())
            {
                // Return only the item which has the same id
                return db.Discounts.FirstOrDefault(m => m.Id == id);
            }
        }

        // POST api/Discounts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Discount value)
        {
            // Use the database object
            using (var db = new Db())
            {
                if (ModelState.IsValid && value.DiscountPercentage != 0)
                {
                    db.Discounts.Add(value);
                    // Save the changes without clogging up the main thread
                    await db.SaveChangesAsync();
                    return new CreatedAtRouteResult("Discounts", value.Id);
                }
                else
                    return new StatusCodeResult(400);
            }
        }

        // PUT api/Discounts/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Discount value)
        {
            // Use the database object
            using (var db = new Db())
            {
                Discount res = db.Discounts.FirstOrDefault(d => d.Id == id);
                db.Discounts.Remove(res);
                if (ModelState.IsValid && value.DiscountPercentage != 0)
                {
                    db.Discounts.Add(value);
                    // Save the changes without clogging up the main thread
                    await db.SaveChangesAsync();
                    return new CreatedAtRouteResult("Discounts", value.Id);
                }
                else
                    return new StatusCodeResult(400);
            }
        }

        // DELETE api/Discounts/5
        [HttpDelete("{id}")]
        public async Task<Discount> Delete(int id)
        {
            using (var db = new Db())
            {
                Discount removed = db.Discounts.FirstOrDefault(d => d.Id == id);
                db.Discounts.Remove(removed);
                await db.SaveChangesAsync();
                return removed;
            }
        }
    }
}
