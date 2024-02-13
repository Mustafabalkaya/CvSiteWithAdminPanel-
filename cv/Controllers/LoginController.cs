using cv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace cv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin a)
        {
            DbCvEntities1 db = new  DbCvEntities1();
            var bilgi = db.TblAdmin.FirstOrDefault(x => x.KULLANICIADI == a.KULLANICIADI && x.SIFRE == a.SIFRE);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICIADI, false);
                Session["KULLANICIADI"] = bilgi.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}