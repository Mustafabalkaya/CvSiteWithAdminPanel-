using cv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cv.Repositories;

namespace cv.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminGetir(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KULLANICIADI = p.KULLANICIADI;
            t.SIFRE = p.SIFRE;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}