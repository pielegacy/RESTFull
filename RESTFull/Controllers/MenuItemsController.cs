using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    [Route("api/[controller]")]
    public class MenuItemsController : Controller
    {
        // GET api/MenuItems?name=example name
        [HttpGet]
        public List<MenuItem> Get(string name = "", string type = "")
        {
            // Use the database object
            var db = new Db();
            // get the menu items
            var result = db.MenuItems.ToList();
            result = name != "" ? db.MenuItems.Where(m => m.Name.ToLower().Contains(name)).ToList() : result;
            result = type != "" ? db.MenuItems.Where(m => m.Type == (MenuItemType)Enum.Parse(typeof(MenuItemType), type)).ToList() : result;
            return result;
        }

        // GET api/MenuItems/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            // Use the database object
            using (var db = new Db())
            {
                // Return only the item which has the same id
                return db.MenuItems.FirstOrDefault(m => m.Id == id);
            }
        }

        // POST api/MenuItems
        [HttpPost]
        public async void Post([FromBody]MenuItem value)
        {
            // Use the database object
            using (var db = new Db())
            {
                db.MenuItems.Add(value);
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
