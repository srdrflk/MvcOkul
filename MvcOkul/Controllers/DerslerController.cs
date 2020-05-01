using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkul.Models.Entity;

namespace MvcOkul.Controllers
{
    public class DerslerController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Dersler
        public ActionResult Index()
        {
            var li = db.TblDersler.ToList();

            return View(li);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblDersler p)
        {
            db.TblDersler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sil = db.TblDersler.Find(id);
            db.TblDersler.Remove(sil);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Listele(int id)
        {
            var li = db.TblDersler.Find(id);
            return View(li);
        }

        public ActionResult Güncelle(TblDersler p)
        {
            var gü = db.TblDersler.Find(p.DersId);
            gü.DersAd = p.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}