using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace dance_club.Models
{
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? id)
        {
            string user = User.Identity.GetUserId();


            var activities = db.Activities.Include(a => a.Categories).ToList();
            if(id.HasValue)
            {
                activities = activities.Where(s => s.CategoryID == id).ToList();
            }

            if(!String.IsNullOrEmpty(user))
            {
                var userList = db.Users_Activities.Where(s => s.UserId == user).ToList();

                foreach (var item in activities)
                {

                    foreach (var item1 in userList)
                    {
                        if (item.ActivityID == item1.ActivityID)
                        {
                            item.User = true;
                        }

                    }

                }

            }
            
            ViewBag.List = db.Categories.ToList();
            return View(activities.ToList());
        }

        public ActionResult Sign(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            

            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sign(int id)
        {
            string user = User.Identity.GetUserId();
            var userList = db.Users_Activities.Where(s => s.UserId == user && s.ActivityID == id);

            if(userList == null)
            {
                Activities activities = db.Activities.Find(id);
                db.Users_Activities.Add(new Users_Activities
                {
                    ActivityID = activities.ActivityID,
                    UserId = User.Identity.GetUserId()
                });
                db.SaveChanges();
            }else
            {
                ViewBag.Error = "Jesteś już zapisany na te zajęcia";
            }
            
            return RedirectToAction("Index","UserManager");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }


        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,Name,Description,Act_Start,Act_End,Price,EmployeeID,CategoryID")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activities);
                db.SaveChanges();
                return RedirectToAction("Activities", "AdminManager");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", activities.CategoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", activities.EmployeeID);
            return View(activities);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", activities.CategoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", activities.EmployeeID);
            return View(activities);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,Name,Description,Act_Start,Act_End,Price,EmployeeID,CategoryID")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Activities", "AdminManager");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", activities.CategoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", activities.EmployeeID);
            return View(activities);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activities activities = db.Activities.Find(id);
            db.Activities.Remove(activities);
            db.SaveChanges();
            return RedirectToAction("Activities", "AdminManager");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
