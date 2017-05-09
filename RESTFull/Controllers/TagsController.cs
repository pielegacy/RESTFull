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
        public List<Tag> Get()
        {
            // Use the database object
            var db = new Db();
            return db.Tags.ToList();
        }

        // GET api/Tags/5
        [HttpGet("{id}")]
        public Tag Get(int id)
        {
            // Use the database object
            using (var db = new Db())
            {
                // Return only the item which has the same id
                return db.Tags.FirstOrDefault(t => t.Id == id);
            }
        }

        // POST api/Tags
        [HttpPost]
        public async void Post([FromBody]Tag value)
        {
            // Use the database object
            using (var db = new Db())
            {
                if (ModelState.IsValid && value.TagName != "" && value.TagName != null)
                    db.Tags.Add(value);
                // Save the changes without clogging up the main thread
                await db.SaveChangesAsync();
            }
        }

        // // PUT api/MenuItems/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/MenuItems/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
