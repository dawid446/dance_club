using dance_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dance_club.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Activities()
        {
            
            return View(db.Activities.ToList());
        }

       
        public ActionResult Caterogies()
        {
            return View(db.Categories.ToList());
        }

       
        public ActionResult Employees()
        {
            return View(db.Employees.ToList());
        }

       
    }
}
