using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShopping.Models;

namespace OnlineJewelleryShopping.Controllers
{
    public class UserRegMstsController : Controller
    {
        private Database1Entities6 db = new Database1Entities6();

        // GET: UserRegMsts
        public ActionResult Index()
        {
            return View(db.UserRegMsts.ToList());
        }

        // GET: UserRegMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            if (userRegMst == null)
            {
                return HttpNotFound();
            }
            return View(userRegMst);
        }

        // GET: UserRegMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,userFname,userLname,address,city,state,mobNo,emailID,dob,cdate,password")] UserRegMst userRegMst)
        {
            if (ModelState.IsValid)
            {
                db.UserRegMsts.Add(userRegMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRegMst);
        }

        // GET: UserRegMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            if (userRegMst == null)
            {
                return HttpNotFound();
            }
            return View(userRegMst);
        }

        // POST: UserRegMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userFname,userLname,address,city,state,mobNo,emailID,dob,cdate,password")] UserRegMst userRegMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRegMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRegMst);
        }

        // GET: UserRegMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            if (userRegMst == null)
            {
                return HttpNotFound();
            }
            return View(userRegMst);
        }

        // POST: UserRegMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            db.UserRegMsts.Remove(userRegMst);
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
