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

        // GET: Activities
        public ActionResult Index(int? id)
        {
            var activities = db.Activities.Include(a => a.Categories).Include(a => a.Employees);
            if(id.HasValue)
            {
                activities = activities.Where(a => a.CategoryID == id);
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
            Activities activities = db.Activities.Find(id);
            db.Users_Activities.Add(new Users_Activities {
                ActivityID = activities.ActivityID,
                UserId= User.Identity.GetUserId()
                 });

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Activities/Details/5
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


        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,Name,Description,Act_Start,Act_End,Price,EmployeeID,CategoryID")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activities);
                db.SaveChanges();
                return RedirectToAction("Index");
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

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,Name,Description,Act_Start,Act_End,Price,EmployeeID,CategoryID")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", activities.CategoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", activities.EmployeeID);
            return View(activities);
        }

        // GET: Activities/Delete/5
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

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activities activities = db.Activities.Find(id);
            db.Activities.Remove(activities);
            db.SaveChanges();
            return RedirectToAction("Index");
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
