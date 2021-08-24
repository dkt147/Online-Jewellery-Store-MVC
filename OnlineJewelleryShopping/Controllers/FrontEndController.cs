using OnlineJewelleryShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelleryShopping.Controllers
{
   
    public class FrontEndController : Controller
    {
        Database1Entities6 db = new Database1Entities6();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Product()
        {
            if (Session["cart"] != null)
            {
                int x = 0;
                List<Cart> li2 = Session["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.bill;
                }
                Session["total"] = x;
            }
           

            Session["msg2"] = "123";
            ProdMst prod = new ProdMst();
            return View(db.ProdMsts.ToList());
        }
        public ActionResult Add(int? id)
        {
            ProdMst p = db.ProdMsts.Where(x => x.Prod_Id == id).SingleOrDefault();
            return View(p);
        }

        List<Cart> li = new List<Cart>();
            [HttpPost]
        public ActionResult Add(ProdMst pro,string qty,int id)
        {
            ProdMst p = db.ProdMsts.Where(x => x.Prod_Id == id).SingleOrDefault();

            Cart c = new Cart();
            c.productid = p.Prod_Id;
            c.productname = p.Prod_Type;
            c.price = p.Prod_Price;
            c.qty = Convert.ToInt16(qty);
            c.bill = c.price * c.qty;

            if (Session["cart"] ==  null)
            {
                li.Add(c);
                Session["cart"] = li;
            }
            else
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                li2.Add(c);
                Session["cart"] = li2;

            }

            return RedirectToAction("Product");
        }

        public ActionResult AddtoCart()
        {

            return View();
        }

        public ActionResult Checkoutinfo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkoutinfo(Checkout ch)
        {
            if (ModelState.IsValid)
            {
                db.Checkouts.Add(ch);
                db.SaveChanges();
                return RedirectToAction("Payment");
            }

            return View(ch);
        }
        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(Payment p)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(p);
                db.SaveChanges();
                Session["final"] = "Order Confirm!!";
                return View();
            }

            Session.Remove("total");
            Session.Remove("cart");

            return View(p);
        }
        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Login(AdminLoginMst admin)
        {
            
           var a = db.AdminLoginMsts.Where(x => x.UserName == admin.UserName && x.Password==admin.Password).FirstOrDefault();
            if (a != null)
            {
                Session["username"] = admin.UserName;
                return RedirectToAction("Dashboard","BackEnd");
            }
            else
            {
                Session["msg"] = "Username & Password Does not match..!";
                return View();
            }
        }
        public ActionResult UserLogin(UserRegMst user)
        {
            Session["uname"] = user.emailID;
            var ven = db.UserRegMsts.Where(x => user.emailID == "daniyal@gmail.com" && user.password == "daniyal123").FirstOrDefault();
            var u = db.UserRegMsts.Where(x => x.emailID == user.emailID && x.password==user.password).FirstOrDefault();
            if (u != null && ven == null)
            {
                return RedirectToAction("Index","FrontEnd");
            }
            

            else if (ven != null)
            {
                return RedirectToAction("VendorList", "FrontEnd");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserRegMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "userId,userFname,userLname,address,city,state,mobNo,emailID,dob,cdate,password")] UserRegMst userRegMst)
        {
            if (ModelState.IsValid)
            {
                db.UserRegMsts.Add(userRegMst);
                db.SaveChanges();
                return RedirectToAction("UserLogin");
            }

            return View(userRegMst);
        }
        //[HttpPost]
        //public JsonResult Product(int id)
        //{
        //    List<CartList> list = new List<CartList>();
        //    CartList c = new CartList();

        //    ProdMst pro = db.ProdMsts.Single(x=>x.Prod_Id== id);
        //    if (Session["cartcounter"] != null)
        //    {
        //        list = Session["cartcounter"] as List<CartList>;
        //    }
        //    if (list.Any(x=>x.Id == id))
        //    {
        //        c = list.Single(x => x.Id == id);
        //        c.Qnt = c.Qnt + 1;
        //    }
        //    else
        //    {
        //        c.Id = id;
        //        c.Product_Name = pro.Prod_Type;
        //        c.Price = pro.Prod_Price;
        //        c.Qnt = pro.Prod_Qnt;
        //        list.Add(c);


        //    }
        //    Session["cartcounter"] = list.Count;
        //    Session["cartitem"] = list;

        //    return Json(new {Success = true, Counter = list.Count},JsonRequestBehavior.AllowGet);
        //}
        public ActionResult CheckOut()
        {
            return View();
        }
        public ActionResult VendorList()
        {
            return View(db.ProdMsts.ToList());
        }
        public ActionResult VendorCreate()
        {
            return View();
        }

        // POST: UserRegMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VendorCreate( ProdMst prod)
        {
            if (ModelState.IsValid)
            {
                db.ProdMsts.Add(prod);
                db.SaveChanges();
                return RedirectToAction("VendorList");
            }

            return View(prod);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "FrontEnd");


        }

    }
}