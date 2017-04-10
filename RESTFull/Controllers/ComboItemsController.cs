using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    [Route("api/[controller]")]
    public class ComboItemsController : Controller
    {
        // GET api/MenuItems?name=example name
        [HttpGet]
        public List<ComboItem> Get()
        {
            // Use the database object
            var db = new Db();
            var result = db.ComboItems.ToList();
            return result;
        }

        // POST api/MenuItems
        [HttpPost]
        public async void Post([FromBody]Discount value)
        {
            // Use the database object
            using (var db = new Db())
            {
                if (ModelState.IsValid && value.DiscountPercentage != 0)
                    db.Discounts.Add(value);
                // Save the changes without clogging up the main thread
                await db.SaveChangesAsync();
            }
        }

        // PUT api/MenuItems/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/MenuItems/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
