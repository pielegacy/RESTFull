using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RESTFull.Models;
using System.Net;
using System.Threading.Tasks;

namespace RESTFull.Controllers
{
    ///<summary>
    /// Store Details stores the information about the establishment/s you are querying
    ///</summary>
    [Route("api/[controller]")]
    public class StoreDetailsController : Controller
    {
        // GET api/StoreDetails
        [HttpGet]
        public IEnumerable<StoreDetails> Get()
        {
            using (var db = new Db())
                return db.StoreDetails;
        }
        // GET api/StoreDetails/{id}
        [HttpGet("{id}")]
        public StoreDetails Get(int id)
        {
            using (var db = new Db())
                return db.StoreDetails.FirstOrDefault(s => s.Id == id);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]StoreDetails value)
        {
            using (var db = new Db())
            {
                if (ModelState.IsValid)
                {
                    await db.StoreDetails.AddAsync(value);
                    await db.SaveChangesAsync();
                    return new CreatedAtRouteResult("StoreDetails", value.Id);
                }
                else
                {
                    return new StatusCodeResult(400);
                }
            }
        }
        // PUT api/StoreDetails/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int? id, [FromBodyAttribute]StoreDetails value)
        {
            using (var db = new Db())
            {
                int newId = id ?? db.StoreDetails.Select(d => d.Id).FirstOrDefault();
                var removed = db.StoreDetails.FirstOrDefault(s => s.Id == newId);
                db.StoreDetails.Remove(removed);
                await db.StoreDetails.AddAsync(value);
                await db.SaveChangesAsync();
                return new CreatedAtRouteResult("StoreDetails", value.Id);
            }
        }
        // DELETE api/StoreDetails/{id}
        [HttpDelete("{id}")]
        public async Task<StoreDetails> Delete(int? id)
        {
            using (var db = new Db())
            {
                var removed = db.StoreDetails.FirstOrDefault(s => s.Id == id);
                db.StoreDetails.Remove(removed);
                await db.SaveChangesAsync();
                return removed;
            }
        }
    }
}
