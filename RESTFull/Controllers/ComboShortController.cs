using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Models;

namespace RESTFull.Controllers
{
    // TODO : Give this a better name

    ///<summary>
    /// ComboShort allows for the creation of combos using the ComboShortHand class
    ///</summary>
    ///<remarks>
    /// This method exists purely to make the creation of combos easier with less requests
    ///</remarks>
    [Route("api/[controller]")]
    public class ComboShortController : Controller
    {
        // POST api/ComboShort
        [HttpPost]
        public async Task<Combo> Post([FromBody]ComboShortHand value)
        {
            if (value.IsValid)
            {
                // Use the database object
                using (var db = new Db())
                {
                    db.Combos.Add(value.Combo);
                    await db.SaveChangesAsync();
                    int newComboId = db.Combos.First(c => c.ComboDescription == value.Combo.ComboDescription && c.ComboPrice == value.Combo.ComboPrice).ComboId;
                    foreach (int i in value.ItemIds)
                    {
                        db.ComboItems.Add(new ComboItem()
                        {
                            MenuItemId = i,
                            ComboId = newComboId
                        });
                    }
                    // Save the changes without clogging up the main thread
                    await db.SaveChangesAsync();
                    return value.Combo;
                }
            }
            else
            {
                return null;
            }
        }
        [HttpPutAttribute("{id}")]
        public async Task<Combo> Put(int id, [FromBody]ComboShortHand value)
        {
            if (value.IsValid)
            {
                // Use the database object
                using (var db = new Db())
                {
                    // Remove existing
                    db.Combos.Remove(db.Combos.FirstOrDefault(c => c.ComboId == id));
                    db.ComboItems.RemoveRange(db.ComboItems.Where(i => i.ComboId == id));
                    // Add new
                    db.Combos.Add(value.Combo);
                    await db.SaveChangesAsync();
                    int newComboId = db.Combos.First(c => c.ComboDescription == value.Combo.ComboDescription && c.ComboPrice == value.Combo.ComboPrice).ComboId;
                    foreach (int i in value.ItemIds)
                    {
                        db.ComboItems.Add(new ComboItem()
                        {
                            MenuItemId = i,
                            ComboId = newComboId
                        });
                    }
                    // Save the changes without clogging up the main thread
                    await db.SaveChangesAsync();
                    return value.Combo;
                }
            }
            else
            {
                return null;
            }
        }
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
