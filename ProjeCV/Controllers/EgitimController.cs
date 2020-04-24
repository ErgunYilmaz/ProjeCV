using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sınıf;
namespace ProjeCV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger3 = db.TBLEDUCATİON.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniEgitim(TBLEDUCATİON p)
        {
            db.TBLEDUCATİON.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var egt = db.TBLEDUCATİON.Find(id);
            db.TBLEDUCATİON.Remove(egt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EgitimGetir(int id)
        {
            var egitim = db.TBLEDUCATİON.Find(id);
            return View("EgitimGetir", egitim);
        }
        public ActionResult Guncelle(TBLEDUCATİON p)
        {
            var degerler = db.TBLEDUCATİON.Find(p.ID);
            degerler.TİTLE = p.TİTLE;
            degerler.SUBTİTLE = p.SUBTİTLE;
            degerler.DEPARTMAN = p.DEPARTMAN;
            degerler.GPA = p.GPA;
            return RedirectToAction("Index");
        }
    }
}