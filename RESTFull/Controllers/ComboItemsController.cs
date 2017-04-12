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
        // GET api/ComboItems
        [HttpGet]
        public List<ComboItem> Get()
        {
            // Use the database object
            var db = new Db();
            var result = db.ComboItems.ToList();
            return result;
        }

        // POST api/ComboItems
        [HttpPost]
        public async void Post([FromBody]ComboItem value)
        {
            // Use the database object
            using (var db = new Db())
            {
                db.ComboItems.Add(value);              
                // Save the changes without clogging up the main thread
                await db.SaveChangesAsync();
            }
        }

        // DELETE api/ComboItems
        [HttpDelete]
        public async void Delete([FromBody]ComboItem value)
        {
            using (var db = new Db())
            {
                db.ComboItems.Remove(value);
                // Save the changes without clogging up the main thread
                await db.SaveChangesAsync();
            }
        }
    }
}
