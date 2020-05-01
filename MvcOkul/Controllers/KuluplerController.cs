using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkul.Models.Entity;

namespace MvcOkul.Controllers
{
    public class KuluplerController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Kulupler
        public ActionResult Index()
        {
            var li = db.TblKulupler.ToList();
            return View(li);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblKulupler p)
        {
            db.TblKulupler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sil = db.TblKulupler.Find(id);
            db.TblKulupler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Listele(int id)
        {
            var li = db.TblKulupler.Find(id);
            return View(li);
        }

        public ActionResult Güncelle(TblKulupler p)
        {
            var s = db.TblKulupler.Find(p.KulupId);
            s.KulupAd = p.KulupAd;
            s.KulupKontenjan = p.KulupKontenjan;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}