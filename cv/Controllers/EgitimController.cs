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

    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.BASLIK = t.BASLIK;
            egitim.ALTBASLIK1 = t.ALTBASLIK1;
            egitim.ALTBASLIK2 = t.ALTBASLIK2;
            egitim.TARIH = t.TARIH;
            egitim.GNO = t.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}