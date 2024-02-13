using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using cv.Models.Entity;
using FluentEmail.Core;
using FluentEmail.Smtp;
using cv.Models;
using MimeKit;

namespace cv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities1 db = new DbCvEntities1();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TblSosyalMedya.Where(x => x.DURUM == true).ToList();
            return PartialView(sosyalMedya);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalarim()
        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(TblIletisim t)
        {
            t.TARIH = DateTime.Now;
            db.TblIletisim.Add(t);
            db.SaveChanges();

            // E-posta gönderme işlemi
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("balkayamustafa99@gmail.com", "yjeyddnxtegjijdc"), // Gönderenin e-posta adresi ve şifresi
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(t.MAIL); // Kullanıcının girdiği e-posta adresi
            mailMessage.To.Add("balkayamustafa99@gmail.com"); // Alıcı adresi sabit olarak "balkayamustafa99@gmail.com"
            mailMessage.Subject = t.KONU;
            mailMessage.Body = Environment.NewLine + "Gönderen Ad Soyad : " + t.ADSOYAD + Environment.NewLine + Environment.NewLine + "Gönderen mail adresi: " + t.MAIL + Environment.NewLine + "MESAJ: " + t.MESAJ;
            smtpClient.Send(mailMessage);

            return PartialView();
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;

            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page500()
        {
            return View();
        }
    }
}