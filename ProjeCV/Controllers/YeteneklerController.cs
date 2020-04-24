using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sınıf;


namespace ProjeCV.Controllers
{
    public class YeteneklerController : Controller
    {
        // GET: Yetenekler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger4 = db.TBLSKILLS.ToList();
            return View(cs);
            
        }
        [HttpGet]
        public  ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLSKILLS p)
        {
            db.TBLSKILLS.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var ytnk = db.TBLSKILLS.Find(id);
            db.TBLSKILLS.Remove(ytnk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YetenekGetir(int id)
        {
            var ytnk = db.TBLSKILLS.Find(id);
            return View("YetenekGetir", ytnk);
        }
        public ActionResult Guncelle(TBLSKILLS  p)
        {
            var degerler = db.TBLSKILLS.Find(p.ID);
            degerler.SKILL = p.SKILL;           
            return RedirectToAction("Index");
        }

    }
}