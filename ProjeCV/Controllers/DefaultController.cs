using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sınıf;

namespace ProjeCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLABOUT.ToList();
            cs.Deger2 = db.TBLEXPERİENCE.ToList();
            cs.Deger3 = db.TBLEDUCATİON.ToList();
            cs.Deger4 = db.TBLSKILLS.ToList();
            cs.Deger5 = db.TBLINTERESTS.ToList();
            cs.Deger6 = db.TBLAWARDS.ToList();
            return View(cs);
            //var degerler = db.TBLABOUT.ToList();
            //return View(degerler);
        }
    }
}