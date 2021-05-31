using kurumsalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace kurumsalWeb.Controllers
{
    
    public class AdminController : Controller
    {
        BlogDb ent = new BlogDb();
        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = ent.tbKategori.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbAdmin admin)
        {
            var login = ent.tbAdmin.Where(x => x.adminPosta == admin.adminPosta&&x.adminSifre==admin.adminSifre).SingleOrDefault();
            if (login!=null)
            {
                Session["adminID"] = login.adminID;
                Session["eposta"] = login.adminPosta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı Adı veya Şifre Hatalı";
            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["adminID"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
            
        }
    }
}