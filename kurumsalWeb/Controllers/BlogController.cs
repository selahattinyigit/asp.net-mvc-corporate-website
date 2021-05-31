using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using kurumsalWeb.Models;
namespace kurumsalWeb.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private BlogDb ent = new BlogDb();
        public ActionResult Index()
        {
               return View(ent.blog.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.kategoriId = new SelectList(ent.tbKategori, "kategoriId", "kategoriAd");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(blog blog,HttpPostedFileBase resimUrl)
        {
            
                WebImage img = new WebImage(resimUrl.InputStream);
                FileInfo imginfo = new FileInfo(resimUrl.FileName);

                string logoname = resimUrl.FileName;
                img.Resize(500, 500);
                img.Save("~/Uploads/Blog/" + logoname);
                blog.resimUrl = "Uploads/Blog/" + logoname;
            
            ent.blog.Add(blog);
            ent.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.kategoriId = new SelectList(ent.tbKategori, "kategoriId", "kategoriAd");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blog b = ent.blog.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
            //return View(ent.blog.Where(x=>x.blogId==id).SingleOrDefault());
        }
        [HttpPost]

        [ValidateInput(false)]
        public ActionResult Edit(int? id, blog b, HttpPostedFileBase resimUrl)
        {
            var k = ent.blog.Where(x => x.blogId == id).SingleOrDefault();
            if (resimUrl != null)
            {
                
                WebImage img = new WebImage(resimUrl.InputStream);
                FileInfo imginfo = new FileInfo(resimUrl.FileName);

                string logoname = resimUrl.FileName;
                img.Resize(300, 200);
                img.Save("~/Uploads/Blog/" + logoname);
                k.resimUrl = "Uploads/Blog/" + logoname;

            }
            k.baslik = b.baslik;
            k.icerik = b.icerik;
            k.kategoriId = b.kategoriId;
            

            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var b = ent.blog.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            ent.blog.Remove(b);
            ent.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}