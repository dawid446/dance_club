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
            if(activities.Any())
            {
                ViewBag.Info = "Twoje aktualne zajęcia";
               
            }else
            {
                ViewBag.Info = "Nie jesteś zapisany na żadne zajęcia. Zapisz sie!";
            }

            return View(activities.ToList());

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
            user = User.Identity.GetUserId();
            Users_Activities users_Activities = db.Users_Activities.Where(s => s.UserId == user && s.ActivityID == id).FirstOrDefault();
           
            db.Users_Activities.Remove(users_Activities);
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
