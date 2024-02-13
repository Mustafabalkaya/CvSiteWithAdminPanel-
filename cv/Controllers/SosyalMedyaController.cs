using cv.Models.Entity;
using cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv.Controllers
{
    [Authorize]
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }

        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya s)
        {
            var hesap = repo.Find(x => x.ID == s.ID);
            hesap.AD = s.AD;
            hesap.DURUM = true;
            hesap.LINK = s.LINK;
            hesap.ICON = s.ICON;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.DURUM = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}