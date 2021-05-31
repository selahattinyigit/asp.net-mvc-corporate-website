using kurumsalWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace kurumsalWeb.Controllers
{
    public class KimlikController : Controller
    {
        BlogDb ent = new BlogDb();
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(ent.tbKimlik.ToList());
        }

        // GET: Kimlik/Details/5
       

        // GET: Kimlik/Create
       

        // POST: Kimlik/Create
      

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = ent.tbKimlik.Where(x => x.kimlik_id == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tbKimlik kimlik,HttpPostedFileBase logoUrl)
        {
            if (ModelState.IsValid)
            {
                var k = ent.tbKimlik.Where(x => x.kimlik_id == id).SingleOrDefault();
                if (logoUrl!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/"+k.logoUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/"+k.logoUrl));
                    }
                    WebImage img =new WebImage(logoUrl.InputStream);
                    FileInfo imginfo = new FileInfo(logoUrl.FileName);

                    string logoname = logoUrl.FileName;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Kimlik/" + logoname);
                    k.logoUrl = "Uploads/Kimlik/" + logoname;
                    
                }
                k.title = kimlik.title;
                k.keyword = kimlik.keyword;
                k.description = kimlik.description;
                k.unvan = kimlik.unvan;
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kimlik);
        }

        // GET: Kimlik/Delete/5
       

        // POST: Kimlik/Delete/5
       
    }
}
