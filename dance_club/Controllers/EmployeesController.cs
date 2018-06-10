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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {

            var employees_Titles = db.Employees_Titles.Include(e => e.Employees).Include(e => e.Titles).OrderBy(s=>s.Employees.Surname);
            
            return View(employees_Titles.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
           

            ActivitiesViewModel ac = new ActivitiesViewModel
            {
               
                Title = db.Titles.ToList()

            };

            return View(ac);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivitiesViewModel activities)
        {
            if (ModelState.IsValid)
            {
                if (activities.titleList?.Length > 0)
                {
                   
                    foreach (var item in activities.titleList)
                    {
                        Employees_Titles titles = new Employees_Titles
                        {
                            EmployeeID = activities.Employees.EmployeeID,
                            TitleID = item
                    };

                    db.Employees_Titles.Add(titles);
                    }

                    db.Employees.Add(activities.Employees);
                
                }
               
                db.SaveChanges();
                return RedirectToAction("Employees", "AdminManager");
            }
           
            return View(activities);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,Surname,Hire_date,Birth_date")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Employees", "AdminManager");
            }
            return View(employees);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
           
            db.Employees.Remove(employees);
            db.SaveChanges();
            return RedirectToAction("Employees", "AdminManager");
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
