using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using kurumsalWeb.Models;

namespace kurumsalWeb.Controllers
{
    public class SliderController : Controller
    {
        private BlogDb db = new BlogDb();

        // GET: Slider
        public ActionResult Index()
        {
            return View(db.tbSlider.ToList());
        }

        // GET: Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSlider tbSlider = db.tbSlider.Find(id);
            if (tbSlider == null)
            {
                return HttpNotFound();
            }
            return View(tbSlider);
        }

        // GET: Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slider/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sliderId,baslik,icerik,resimUrl")] tbSlider slider,HttpPostedFileBase resimUrl)
        {
            if (ModelState.IsValid)
            {
                WebImage img = new WebImage(resimUrl.InputStream);
                FileInfo imginfo = new FileInfo(resimUrl.FileName);

                string logoname = resimUrl.FileName;
                img.Resize(1024, 360);
                img.Save("~/Uploads/Slider/" + logoname);
                slider.resimUrl = "Uploads/Slider/" + logoname;

                db.tbSlider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
             
            }

            return View(slider);
        }

        // GET: Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSlider tbSlider = db.tbSlider.Find(id);
            if (tbSlider == null)
            {
                return HttpNotFound();
            }
            return View(tbSlider);
        }

        // POST: Slider/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,tbSlider slider, HttpPostedFileBase resimUrl)
        {
            if (ModelState.IsValid)
            {
                var k = db.tbSlider.Where(x => x.sliderId ==id ).SingleOrDefault();
                if (resimUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/"+k.resimUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/" + k.resimUrl));
                    }
                    WebImage img = new WebImage(resimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(resimUrl.FileName);

                    string logoname = resimUrl.FileName;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + logoname);
                    k.resimUrl = "Uploads/Slider/" + logoname;

                }
                k.baslik = slider.baslik;
                k.icerik = slider.icerik;
                db.SaveChanges();
                return RedirectToAction("Index");
            
            }
            return View(slider);
        }

        // GET: Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSlider tbSlider = db.tbSlider.Find(id);
            if (tbSlider == null)
            {
                return HttpNotFound();
            }
            return View(tbSlider);
        }

        // POST: Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbSlider tbSlider = db.tbSlider.Find(id);
            db.tbSlider.Remove(tbSlider);
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
