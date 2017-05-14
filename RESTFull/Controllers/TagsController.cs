using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        // GET api/Tags
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Use the database object
            var db = new Db();
            return db.Tags.Select(t => t.TagName).Distinct();
        }

        // POST api/Tags
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Tag value)
        {
            // Use the database object
            using (var db = new Db())
            {
                if (ModelState.IsValid && value.TagName != "" && value.TagName != null)
                {
                    db.Tags.Add(value);
                    // Save the changes without clogging up the main thread
                    await db.SaveChangesAsync();
                    return new CreatedAtRouteResult("Tags", value.Id);
                }
                else
                    return new StatusCodeResult(400);
            }
        }

        // DELETE api/Tags/5
        [HttpDelete("{id}")]
        public async Task<Tag> Delete(int id)
        {
            using (var db = new Db())
            {
                var removed = db.Tags.FirstOrDefault(t => t.Id == id);
                db.Tags.Remove(removed);
                await db.SaveChangesAsync();
                return removed;
            }
        }
    }
}
