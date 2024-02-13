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

    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.BASLIK = p.BASLIK;
            t.ALTBASLIK = p.ALTBASLIK;
            t.TARIH = p.TARIH;
            t.ACIKLAMA = p.ACIKLAMA;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}