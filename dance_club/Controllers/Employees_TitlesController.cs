using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dance_club.Models;

namespace dance_club.Controllers
{
    public class Employees_TitlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees_Titles
        public ActionResult Index()
        {
            var employees_Titles = db.Employees_Titles.Include(e => e.Employees).Include(e => e.Titles);
            return View(employees_Titles.ToList());
        }

        // GET: Employees_Titles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees_Titles employees_Titles = db.Employees_Titles.Find(id);
            if (employees_Titles == null)
            {
                return HttpNotFound();
            }
            return View(employees_Titles);
        }

        // GET: Employees_Titles/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "Name");
            return View();
        }

        // POST: Employees_Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeTitleID,TitleID,EmployeeID")] Employees_Titles employees_Titles)
        {
            if (ModelState.IsValid)
            {
                db.Employees_Titles.Add(employees_Titles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", employees_Titles.EmployeeID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "Name", employees_Titles.TitleID);
            return View(employees_Titles);
        }

        // GET: Employees_Titles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees_Titles employees_Titles = db.Employees_Titles.Find(id);
            if (employees_Titles == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", employees_Titles.EmployeeID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "Name", employees_Titles.TitleID);
            return View(employees_Titles);
        }

        // POST: Employees_Titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeTitleID,TitleID,EmployeeID")] Employees_Titles employees_Titles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees_Titles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", employees_Titles.EmployeeID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "Name", employees_Titles.TitleID);
            return View(employees_Titles);
        }

        // GET: Employees_Titles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees_Titles employees_Titles = db.Employees_Titles.Find(id);
            if (employees_Titles == null)
            {
                return HttpNotFound();
            }
            return View(employees_Titles);
        }

        // POST: Employees_Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees_Titles employees_Titles = db.Employees_Titles.Find(id);
            db.Employees_Titles.Remove(employees_Titles);
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
