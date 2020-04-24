using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sınıf;

namespace ProjeCV.Controllers
{
    public class DeneyimlerController : Controller
    {
        // GET: Deneyimler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger2 = db.TBLEXPERİENCE.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniDeneyim()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult YeniDeneyim(TBLEXPERİENCE p)
        {
            db.TBLEXPERİENCE.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeneyimSil(int id)
        {
            var deneyim = db.TBLEXPERİENCE.Find(id);
            db.TBLEXPERİENCE.Remove(deneyim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimGetir(int id)
        {
            var veri = db.TBLEXPERİENCE.Find(id);
            return View("DeneyimGetir",veri);
        }
        public ActionResult Guncelle(TBLEXPERİENCE p)
        {
            var veriler = db.TBLEXPERİENCE.Find(p.ID);
            veriler.TİTLE = p.SUBTİTLE;
            veriler.SUBTİTLE = p.SUBTİTLE;
            veriler.DETAİLS = p.DETAİLS;
            veriler.DATE = p.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}