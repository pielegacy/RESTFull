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
            foreach (var r in result)
                r.ComboToMenuItems();
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
                Combo result = db.Combos.FirstOrDefault(m => m.ComboId == id);
                if (result != null)
                    result.ComboToMenuItems();
                return result;
            }
        }

        // POST api/Combos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Combo value)
        {
            if (ModelState.IsValid)
            {
                // Use the database object
                using (var db = new Db())
                {
                    db.Combos.Add(value);
                    // Save the changes without clogging up the main thread
                    await db.SaveChangesAsync();
                    return new CreatedAtRouteResult("ComboItems", db.Combos.First(c => c.ComboDescription == value.ComboDescription).ComboId);
                }
            }
            else
            {
                return new StatusCodeResult(400);
            }
        }
        // PUT api/Combos/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]Combo value)
        {
            value.ComboId = id;
            using (var db = new Db())
            {
                db.Combos.Update(value);
                // Save the changes without clogging up the main thread
                await db.SaveChangesAsync();
            }
        }

        // DELETE api/Combos/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            using (var db = new Db())
            {
                if (db.Combos.Where(a => a.ComboId == id).Count() > 0)
                    db.Combos.Remove(db.Combos.FirstOrDefault(m => m.ComboId == id));
                // Save the changes without clogging up the main thread
                await db.SaveChangesAsync();
            }
        }
    }
}
