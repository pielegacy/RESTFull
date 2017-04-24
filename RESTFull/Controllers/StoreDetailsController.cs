using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RESTFull.Models;

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
    }
}
