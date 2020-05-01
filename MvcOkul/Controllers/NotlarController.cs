using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkul.Models.Entity;
using MvcOkul.Models;

namespace MvcOkul.Controllers
{
    public class NotlarController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Notlar
        public ActionResult Index()
        {
            var li = db.TblNotlar.ToList();
            return View(li);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblNotlar p)
        {
            db.TblNotlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Listele(int id)
        {
            var li = db.TblNotlar.Find(id);
            return View(li);
        }
        [HttpPost]
        public ActionResult Listele(Class1 model, TblNotlar p, int sinav1 = 0, int sinav2 = 0, int sinav3 = 0, int proje = 0)
        {
            if (model.islem == "Hesapla")
            {
                int ort = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ortalama = ort;
            }
            if (model.islem == "NotGuncelle")
            {
                var gü = db.TblNotlar.Find(p.NotId);
                gü.Sinav1 = p.Sinav1;
                gü.Sinav2 = p.Sinav2;
                gü.Sinav3 = p.Sinav3;
                gü.Proje = p.Proje;
                gü.Ortalama = p.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}