using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using kurumsalWeb.Models;

namespace kurumsalWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BlogDb ent = new BlogDb();
        public ActionResult Index()
        {
            ViewBag.hizmet = ent.tbHizmet.ToList();
            return View();
        }
        public ActionResult SliderPartial()
        {
            return View(ent.tbSlider.ToList().OrderByDescending(x => x.sliderId));
        }
        public ActionResult HizmetPartial()
        {
            return View(ent.tbHizmet.ToList().OrderByDescending(x => x.hizmetId));
        }
        public ActionResult Hakkimizda()
        {
            
            return View(ent.tbHakkimizda.Single());
        }
        public ActionResult Hizmetlerimiz()
        {
            return View(ent.tbHizmet.ToList().OrderByDescending(x=>x.hizmetId));
        }
        public ActionResult Iletisim()
        {
            return View(ent.iletisim.SingleOrDefault()) ;
        }
        [HttpPost]
        public ActionResult Iletisim(string adsoyad=null,string email=null,string konu=null,string mesaj=null)
        {
            if (adsoyad!=null && email!=null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "selahattin.ygt50@gmail.com";
                WebMail.Password = "50905090";
                WebMail.SmtpPort = 587;
                WebMail.Send("selahattin.ygt50@gmail.com", konu,adsoyad+"-"+ email + "\n" + mesaj);
                ViewBag.uyari = "Mesajınız Gönderildi. Teşekkür Ederiz!";
            }
            else
            {
                ViewBag.uyari = "Bir hata oluştu tekrar deneyiniz";
            }
            return View();
        }
        public ActionResult SiteFooter()
        {
           ViewBag.hizmet = ent.tbHizmet.ToList().OrderByDescending(x => x.hizmetId);

            ViewBag.iletisim = ent.iletisim.SingleOrDefault();

            ViewBag.blog = ent.blog.ToList().OrderByDescending(x => x.blogId);
            return PartialView();
        }


    }
}