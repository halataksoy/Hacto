using HACTO.Models;
using HACTO.Models.DataContext;
using HACTO.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace HACTO.Controllers
{
    public class AdminController : Controller
    {
        HactoDBContext db = new HactoDBContext();
        // GET: Admin
        [Route("yonetimpaneli")]
        public ActionResult Index()
        {
            ViewBag.HizmetSay = db.Hizmet.Count();
            ViewBag.SliderSay = db.Slider.Count();
            ViewBag.KimlikSay = db.Kimlik.Count();
            return View();
        }
        [Route("yonetimpaneli/giris/")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin,string sifre)
        {
        
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();//dbdeki admin tablosyna bak ve admin modeiyle eşleşen bir e posta var mı?
            if (login.Eposta==admin.Eposta && login.Sifre==Crypto.Hash(admin.Sifre,"MD5"))
            {
                //session bir oturum değişkeni oluşturmamızı sağlar.
                Session["adminid"] = login.AdminId;
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı veya şifre yanlış";
            return View();
        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();//tüm sessionları düşürür
            return RedirectToAction("Login", "Admin");
        }
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
        public ActionResult Adminler()
        {
            return View(db.Admin.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin,string sifre, string eposta)
        {
            if (ModelState.IsValid)
            {
                admin.Sifre = Crypto.Hash(sifre,"MD5");
                db.Admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Adminler");
            }
            return View(admin);
        }
        public ActionResult Edit(int id)
        {
            var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
            return View(a);
        }    
        [HttpPost]
        public ActionResult Edit(int id,Admin admin,string sifre,string eposta)
        {

            if (ModelState.IsValid)
            {
                var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
                a.Sifre = Crypto.Hash(sifre, "MD");
                a.Eposta = admin.Eposta;
                a.Yetki = admin.Yetki;
                db.SaveChanges();
                return RedirectToAction("Adminler");

            }
            return View(admin);
        }
        public ActionResult Delete(int id)
        {
            var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
            if (a!=null)
            {
                db.Admin.Remove(a);
                db.SaveChanges();
                return RedirectToAction("Adminler");
            }

            return View(a);
        }
            
    }
}