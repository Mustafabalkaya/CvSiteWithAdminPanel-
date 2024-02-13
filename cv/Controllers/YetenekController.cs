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

    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.YETENEK = t.YETENEK;
            y.ORAN = t.ORAN;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}