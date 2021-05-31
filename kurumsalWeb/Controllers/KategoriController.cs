using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kurumsalWeb.Models;

namespace kurumsalWeb.Controllers
{
    public class KategoriController : Controller
    {
        private BlogDb db = new BlogDb();

        // GET: tbKategoris
        public ActionResult Index()
        {
            return View(db.tbKategori.ToList());
        }

        // GET: tbKategoris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbKategori tbKategori = db.tbKategori.Find(id);
            if (tbKategori == null)
            {
                return HttpNotFound();
            }
            return View(tbKategori);
        }

        // GET: tbKategoris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbKategoris/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kategori_id,kategoriAd,aciklama")] tbKategori tbKategori)
        {
            if (ModelState.IsValid)
            {
                db.tbKategori.Add(tbKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbKategori);
        }

        // GET: tbKategoris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbKategori tbKategori = db.tbKategori.Find(id);
            if (tbKategori == null)
            {
                return HttpNotFound();
            }
            return View(tbKategori);
        }

        // POST: tbKategoris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kategori_id,kategoriAd,aciklama")] tbKategori tbKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbKategori);
        }

        // GET: tbKategoris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbKategori tbKategori = db.tbKategori.Find(id);
            if (tbKategori == null)
            {
                return HttpNotFound();
            }
            return View(tbKategori);
        }

        // POST: tbKategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbKategori tbKategori = db.tbKategori.Find(id);
            db.tbKategori.Remove(tbKategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
