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
            foreach (MenuItem m in result)
                m.Link(db);
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
                MenuItem res = db.MenuItems.FirstOrDefault(m => m.Id == id);
                if (res != null)
                    res.Link(db);
                return res;
            }
        }

        // POST api/MenuItems
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]MenuItem value)
        {
            // Use the database object
            using (var db = new Db())
            {
                // Ensure that invalid discountIds are taken into account
                if (value.DiscountId.HasValue && !db.Discounts.Select(d => d.Id).ToList().Contains(value.DiscountId.Value))
                    value.DiscountId = null;
                if (ModelState.IsValid)
                {
                    db.MenuItems.Add(value);
                    // Save the changes without clogging up the main thread
                    await db.SaveChangesAsync();
                    return new CreatedAtRouteResult("MenuItems", value.Id);
                }
                else
                    return new StatusCodeResult(400);
            }
        }

        // PUT api/MenuItems/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]MenuItem value)
        {
            using (var db = new Db())
            {
                MenuItem res = db.MenuItems.FirstOrDefault(m => m.Id == id);
                db.MenuItems.Remove(res);
                // Ensure we are not setting a null element
                if (res != null)
                {
                    res = value;
                    await db.MenuItems.AddAsync(res);
                    await db.SaveChangesAsync();
                    return new CreatedAtRouteResult("MenuItems", value.Id);
                }
                else
                    return new StatusCodeResult(400);
            }
        }

        // DELETE api/MenuItems/5
        [HttpDelete("{id}")]
        public async Task<MenuItem> Delete(int id)
        {
            using (var db = new Db())
            {
                var removed = db.MenuItems.FirstOrDefault(m => m.Id == id);
                db.MenuItems.Remove(removed);
                await db.SaveChangesAsync();
                return removed;
            }
        }
    }
}
