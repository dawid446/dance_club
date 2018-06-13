using dance_club.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dance_club.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetCalendarData()
        {
            
           
            List<CalendarViewModel> list = new List<CalendarViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var listdatabase = db.Activities.ToList();
                foreach (var item in listdatabase)
                {
                    CalendarViewModel cv = new CalendarViewModel
                    {
                        ActivityID = item.ActivityID,
                        Name = item.Name,
                        Description = item.Description,
                        Act_Start = item.Act_Start,
                        Act_End = item.Act_End
                       
                       
                    };
                    list.Add(cv);
                }
            }

            
 
             return Json(list, JsonRequestBehavior.AllowGet);
            
               
        }
    }
}