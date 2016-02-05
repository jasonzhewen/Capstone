using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OmniDrome.DataAccessLayer;
using OmniDrome.Models;

namespace OmniDrome.Controllers
{
    public class PersonalDetailsController : Controller
    {
        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();

        // GET: PersonalDetails
        public ActionResult Index()
        {
            var personalInfoes = db.PersonalInfoes.Include(p => p.UserInfo);
            return View(personalInfoes.ToList());
        }

        // GET: PersonalDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails personalDetails = db.PersonalInfoes.Find(id);
            if (personalDetails == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails);
        }

        // GET: PersonalDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserInfoID = new SelectList(db.UserInfoes, "Id", "Email");
            return View();
        }

        // POST: PersonalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,contactNumber,profession,currentCity,currentCountry,dateOfBirth,imageUrl,UserInfoID")] PersonalDetails personalDetails)
        {
            if (ModelState.IsValid)
            {
                db.PersonalInfoes.Add(personalDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserInfoID = new SelectList(db.UserInfoes, "Id", "Email", personalDetails.UserInfoID);
            return View(personalDetails);
        }

        // GET: PersonalDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails personalDetails = db.PersonalInfoes.Find(id);
            if (personalDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserInfoID = new SelectList(db.UserInfoes, "Id", "Email", personalDetails.UserInfoID);
            return View(personalDetails);
        }

        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,contactNumber,profession,currentCity,currentCountry,dateOfBirth,imageUrl,UserInfoID")] PersonalDetails personalDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserInfoID = new SelectList(db.UserInfoes, "Id", "Email", personalDetails.UserInfoID);
            return View(personalDetails);
        }

        // GET: PersonalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails personalDetails = db.PersonalInfoes.Find(id);
            if (personalDetails == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalDetails personalDetails = db.PersonalInfoes.Find(id);
            db.PersonalInfoes.Remove(personalDetails);
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
