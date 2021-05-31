using kurumsalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kurumsalWeb.Controllers
{
    public class HakkimizdaController : Controller
    {
        // GET: Hakkimizda
        BlogDb ent = new BlogDb();
        public ActionResult Index()
        {
            var h = ent.tbHakkimizda.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = ent.tbHakkimizda.Where(x => x.hakkimizdaId == id).FirstOrDefault();
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tbHakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimizda = ent.tbHakkimizda.Where(x => x.hakkimizdaId == id).SingleOrDefault();
                hakkimizda.aciklama = h.aciklama;
                ent.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h);
        }
    }
}