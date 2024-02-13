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

    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(TblHobilerim h)
        {
            var t = repo.Find(x => x.ID == 1);
            t.ACIKLAMA1 = h.ACIKLAMA1;
            t.ACIKLAMA2 = h.ACIKLAMA2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}