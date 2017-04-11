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
        public async Task<ActionResult> Post([FromBody]ComboShortHand value)
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
                    return new CreatedAtRouteResult("Combo", newComboId);
                }
            }
            else
            {
                return new StatusCodeResult(400);
            }
        }
    }
}
