using OnlineJewelleryShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelleryShopping.Controllers
{
    public class BackEndController : Controller
    {
        Database1Entities6 db = new Database1Entities6();

        [HttpGet]
        public ActionResult CreateDashboard()
        {
            return View();

        }
        [HttpPost]
        // GET: BackEnd
        public ActionResult CreateDashboard(UserRegMst user)
        {
            db.UserRegMsts.Add(user);
            db.SaveChanges();
            return RedirectToAction("Dashboard","BackEnd");


        }
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


        public ActionResult Dashboard()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.UserRegMsts.ToList());
            }

        }
        public ActionResult Brand()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.BrandMsts.ToList());
            }

        }
        public ActionResult Cart()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.CartLists.ToList());
            }

        }
        public ActionResult Cat()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.CatMsts.ToList());
            }

        }
        public ActionResult Certify()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.CertifyMsts.ToList());
            }

        }
        public ActionResult DimInfo()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.DimInfoMsts.ToList());
            }

        }
        public ActionResult Dim()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.DimMsts.ToList());
            }

        }
        public ActionResult DimQlty()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.DimQltyMsts.ToList());
            }

        }
        public ActionResult DimQltySub()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.DimQltySubMsts.ToList());
            }

        }
        public ActionResult GoldKrt()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.GoldKrtMsts.ToList());
            }

        }
        public ActionResult Inquiry()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.Inquiries.ToList());
            }

        }
        public ActionResult Item()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.ItemMsts.ToList());
            }

        }
        public ActionResult JewelType()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.JewelTypeMsts.ToList());
            }

        }
        public ActionResult Prod()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.ProdMsts.ToList());
            }

        }
        public ActionResult Stone()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.StoneMsts.ToList());
            }

        }
        public ActionResult StoneQlty()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "FrontEnd");
            }
            else
            {
                return View(db.StoneQltyMsts.ToList());
            }

        }
        public ActionResult Logout()
        {
            Session.Abandon();
                return RedirectToAction("Login", "FrontEnd");
            

        }
    }
}