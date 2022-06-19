using HACTO.Models.DataContext;
using HACTO.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HACTO.Controllers
{
    public class HakkimizdaController : Controller
    {
        //HACTO.Models.DataContext.HactoDBContext db = new Models.DataContext.HactoDBContext(); böyle de ekleyebilirsin
        HactoDBContext db = new HactoDBContext();
        // GET: Hakkiimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);//gelen hakkimizda verilerini listeleyip viewe gönderiyoruz.
        }
        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();//hakkımızdadaki int id değerine göre ilk kaydı bize bul ve getir
            return View(h);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]//verilerin güvenli şekilde gönderilmesini sağlıyor
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda h)
        {
            if (ModelState.IsValid)//modelimiz doğrulandıysa bu işlemleri sağla
            {
                var hakkimizda = db.Hakkimizda.Where(X => X.HakkimizdaId == id).SingleOrDefault();
                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h);
        }
    }
}