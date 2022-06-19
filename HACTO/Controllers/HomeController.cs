using HACTO.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HACTO.Models.Model;


namespace HACTO.Controllers
{

    public class HomeController : Controller
    {
        private HactoDBContext db = new HactoDBContext(); 
        [Route("Anasayfa")] 
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId); /*partial oluşturmasaydık bunu yapabilirdik*/
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            //ViewBag.İletisim = db.İletisim.SingleOrDefault();
            return View();
        }
        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));//orderbydescendşng en sondaki sliderı en başta da görmemizi sağlar.tersten sıralayacak
        }
        public ActionResult HizmetPartial()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));
        }
        [Route("Hakkimizda")]
        public ActionResult Hakkimizda()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hakkimizda.SingleOrDefault());
        }
        [Route("Hizmetlerimiz")]
        public ActionResult Hizmetlerimiz()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }
        [Route("İletisim")]
        public ActionResult İletisim()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.İletisim.ToList().OrderByDescending(x => x.İletisimId));
        }
        [HttpPost]
        public ActionResult İletisim(string adsoyad=null,string email=null,string konu=null,string mesaj=null)
        {
            if (adsoyad!=null && email!=null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;//güvenli bağlantı oluştur
                WebMail.UserName = "hactoyazilim@gmail.com";
                WebMail.Password = "123456789hacto";
                WebMail.SmtpPort = 587;
                WebMail.Send("hactoyazilim@gmail.com",konu,email+"-"+mesaj);
                ViewBag.Uyari = "Mesajınız başarıyla gönderilmiştir.";
            }
            else
            {
                ViewBag.Uyari = "Hata oluştu.Tekrar Deneyin";
            }
           
            return View();
        }
        public ActionResult FooterPartial()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId); /*partial oluşturmasaydık bunu yapabilirdik*/
            ViewBag.İletisim = db.İletisim.SingleOrDefault();
            return PartialView();
        }

    }
}