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

    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<TblIletisim> repo = new GenericRepository<TblIletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}