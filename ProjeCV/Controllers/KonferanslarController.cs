using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sınıf;

namespace ProjeCV.Controllers
{
    public class KonferanslarController : Controller
    {
        // GET: Konferansnlar
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLAWARDS select d;
            if (!string.IsNullOrEmpty(p) )
            {
                degerler = degerler.Where(m => m.AWARD.Contains(p));
            }
            //Class1 cs = new Class1();
            //cs.Deger6 = db.TBLAWARDS.ToList();
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniKonferans()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKonferans(TBLAWARDS p)
        {
            db.TBLAWARDS.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var knfrns = db.TBLAWARDS.Find(id);
            db.TBLAWARDS.Remove(knfrns);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KonferansGetir(int id)
        {
            var veri = db.TBLAWARDS.Find(id);
            return View("KonferansGetir", veri);
        }
        public ActionResult Guncelle(TBLAWARDS p)
        {
            var veriler = db.TBLAWARDS.Find(p.ID);
            veriler.AWARD = p.AWARD;
            
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}