using kurumsalWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace kurumsalWeb.Controllers
{
    public class HizmetController : Controller
    {
        // GET: Hizmet
        BlogDb ent = new BlogDb();

        public ActionResult Index()
        {
            return View(ent.tbHizmet.ToList()) ;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        [ValidateInput(false)]
        public ActionResult Create(tbHizmet hizmet, HttpPostedFileBase resimUrl)
        {
            if (ModelState.IsValid)
            {
                if (resimUrl != null)
                {
                    WebImage img = new WebImage(resimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(resimUrl.FileName);

                    string logoname = resimUrl.FileName;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/" + logoname);
                    hizmet.resimUrl = "Uploads/Hizmet/" + logoname;
                }


                ent.tbHizmet.Add(hizmet);
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hizmet);
        
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbHizmet hizmet = ent.tbHizmet.Find(id);
            if (hizmet == null)
            {
                return HttpNotFound();
            }
            return View(hizmet);
        }
        [HttpPost]
        
        [ValidateInput(false)]
        public ActionResult Edit(int? id,tbHizmet hizmet, HttpPostedFileBase resimUrl)
        {
            if (ModelState.IsValid)
            {
                var k = ent.tbHizmet.Where(x => x.hizmetId == id).SingleOrDefault();
                if ( resimUrl!= null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.resimUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.resimUrl));
                    }
                    WebImage img = new WebImage(resimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(resimUrl.FileName);

                    string logoname = resimUrl.FileName;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/" + logoname);
                    k.resimUrl = "Uploads/Hizmet/" + logoname;

                }
                k.baslik = hizmet.baslik;
                k.aciklama = hizmet.aciklama;
             
               
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hizmet);
        }
        public ActionResult Delete(int id)
        {
            if (id==null)
            {
                return HttpNotFound();

            }
            var h = ent.tbHizmet.Find(id);
            if (h==null)
            {
                return HttpNotFound();
            }
            ent.tbHizmet.Remove(h);
            ent.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}