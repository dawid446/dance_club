using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dance_club.Models;
using Microsoft.AspNet.Identity;

namespace dance_club.Controllers
{
    public class UserManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public string user { get; set; }

        // GET: UserManager
        public ActionResult Index()
        {
      
            user = User.Identity.GetUserId();
            var activities = db.Activities.Where(s=> s.Users_Activities.Any(c=> c.UserId == user)).Include(a => a.Categories);
            return View(activities.ToList());

        }

        // GET: UserManager/Details/5
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

        // GET: UserManager/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
            return View();
        }

        // POST: UserManager/Create
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

        // GET: UserManager/Edit/5
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

        // POST: UserManager/Edit/5
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

        // GET: UserManager/Delete/5
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

        // POST: UserManager/Delete/5
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
