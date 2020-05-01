using MvcOkul.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkul.Controllers
{
    public class OgrencilerController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Ogrenciler
        public ActionResult Index()
        {
            var li = db.TblOgrenciler.ToList();

            return View(li);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> klp = (from x in db.TblKulupler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KulupAd,
                                            Value = x.KulupId.ToString()
                                        }).ToList();
            ViewBag.mesaj = klp;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblOgrenciler p)
        {
            var klp = db.TblKulupler.Where(x => x.KulupId == p.TblKulupler.KulupId).FirstOrDefault();
            p.TblKulupler = klp;
            db.TblOgrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sil = db.TblOgrenciler.Find(id);
            db.TblOgrenciler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Listele(int id)
        {
            var li = db.TblOgrenciler.Find(id);
            List<SelectListItem> klp = (from x in db.TblKulupler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KulupAd,
                                            Value = x.KulupId.ToString()
                                        }).ToList();
            ViewBag.mesaj = klp;
            return View(li);
        }

        public ActionResult Güncelle(TblOgrenciler p)
        {
            var gü = db.TblOgrenciler.Find(p.OgrId);
            gü.OgrAd = p.OgrAd;
            gü.OgrSoyad = p.OgrSoyad;
            gü.OgrFoto = p.OgrFoto;
            gü.OgrCinsiyet = p.OgrCinsiyet;
            gü.OgrKulup = p.OgrKulup;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}