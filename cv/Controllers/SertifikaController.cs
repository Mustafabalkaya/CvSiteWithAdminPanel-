using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cv.Models.Entity;
using cv.Repositories;


namespace cv.Controllers
{
    [Authorize]
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>() { };
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim s)
        {
            var sertifika = repo.Find(x => x.ID == s.ID);
            sertifika.ACIKLAMA = s.ACIKLAMA;
            sertifika.TARIH = s.TARIH;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}