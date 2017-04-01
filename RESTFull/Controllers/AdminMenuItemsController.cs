using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RESTFull.Controllers
{
    [Route("admin/[controller]")]
    public class AdminMenuItems : Controller
    {
        // GET admin/AdminMenuItems
        public IActionResult Index()
        {
            ViewBag.Title = "Page";
            // Use the database object
            var db = new Db();
            return View(db.MenuItems.ToList());
        }
    }
}
