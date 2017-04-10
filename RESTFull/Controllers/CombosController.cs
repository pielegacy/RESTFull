using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    [Route("api/[controller]")]
    public class CombosController : Controller
    {
        // GET api/Combos
        [HttpGet]
        public List<Combo> Get()
        {
            // Use the database object
            var db = new Db();
            var result = db.Combos.ToList();
            foreach (var c in result)
            {
                foreach (var i in db.ComboItems.ToList())
                {
                    if (i.ComboId == c.ComboId)
                        c.Items.Add(db.MenuItems.First(m => m.Id == i.MenuItemId));
                }
            }
            return result;
        }

        // GET api/Combos/5
        [HttpGet("{id}")]
        public Combo Get(int id)
        {
            // Use the database object
            using (var db = new Db())
            {
                // Return only the item which has the same id
                return db.Combos.FirstOrDefault(m => m.ComboId == id);
            }
        }

        // POST api/MenuItems
        [HttpPost]
        public async void Post([FromBody]Combo value)
        {
            // Use the database object
            using (var db = new Db())
            {
                db.Combos.Add(value);
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
