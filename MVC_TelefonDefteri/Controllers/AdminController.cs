using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using MVC_TelefonDefteri.Entities;
using MVC_TelefonDefteri.Methods;
using MVC_TelefonDefteri.Models;

namespace MVC_TelefonDefteri.Controllers
{
    public class AdminController : Controller
    {
        KisiYoneticisi KY = new KisiYoneticisi();
      
        [HttpGet]
        public ActionResult Login()
        {
            KullaniciYonetimi KY = new KullaniciYonetimi();
            if (Session["Kullanici"]!=null)
            {                
                if (KY.KullaniciVarMi((Kullanici)Session["Kullanici"]))
                {
                    return Redirect("Index");
                }
                else
                {
                    ViewBag.Hata = "Kullanici adı & şifre hatalı";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(Kullanici K)
        {
            KullaniciYonetimi KY = new KullaniciYonetimi();
            try
            {
                
                if (KY.KullaniciVarMi(K))
	            {
                    Session["Kullanici"] = KY.KullaniciGetir(K);
                    return Redirect("Index");                   
                }
                else
                {
                    ViewBag.Hata = "Kullanici adı & şifre hatalı";
                    return View(K);
                }
            }
            catch (Exception)
            {
                
                return Redirect("Login");
            }

           
        }
        // GET: Admin
        public ActionResult Index()
        {
            if (!KullaniciIslem.GirisOnay((Kullanici)Session["Kullanici"]))
            {
                return Redirect("Login");
            }
            
            ViewBag.Title = "Yönetim";
            Int16 Sayfa;

            #region Sayfa Numarasi Alma
            if (Request.QueryString["P"] == null)
            {
                Sayfa = 1;
            }
            else
            {
                try
                {
                    Sayfa = Convert.ToInt16(Request.QueryString["P"]);
                }
                catch (Exception)
                {

                    Sayfa = 1;
                }

            }
            #endregion

            List<Kisi> Liste = KY.GetirKisiler(Sayfa);
            return View(Liste);
        }


        // GET: Admin/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Kisi K, HttpPostedFileBase ImageUpload)
        {
      
            try
            {
                byte[] ImageByteArray;
                using (Stream inputStream = ImageUpload.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    ImageByteArray = memoryStream.ToArray();
                }
                if (ModelState.IsValid)
                {
                    K.Photo = ImageByteArray;
                    KY.KisiEkle(K);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Hata = "Kayıt Başarısız";
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int K=1)
        {
           
            Kisi kisi = KY.GetirKisiler(K);
            return View(kisi);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Kisi collection, HttpPostedFileBase ImageUpload)
        {
          
            try
            {
                if (ImageUpload!=null)
                {
                    byte[] ImageByteArray;
                    using (Stream inputStream = ImageUpload.InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        ImageByteArray = memoryStream.ToArray();
                    }

                    Kisi K = KY.KisiGuncelle(collection, ImageByteArray);

                    return View("Edit",K);
                }
                else
                {
                    Kisi K = KY.KisiGuncelle(collection, null);
                    return View("Edit", K);
                }
                
            }
            catch
            {
                return RedirectToAction("Index","Admin");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int K)
        {
     
            KY.KisiSil(K);
            return RedirectToAction("Index","Admin");
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
  
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public PartialViewResult MailEkle(EmailModel emailModels)
        {
           
            EPosta EP = KY.EPostaEkle(emailModels.Email, emailModels.KisiId);
            ViewBag.EPostaID = EP.Id;
            return PartialView("_EmailEklePartial", EP);
        }
        [HttpPost]
        public PartialViewResult PhoneEkle(PhoneModel phoneModels)
        {         
            Telefon Tel = KY.TelEkle(phoneModels.Phone, phoneModels.KisiId);
            ViewBag.TelID = Tel.Id;
            return PartialView("_TelefonEklePartial", Tel);
        }
        [HttpPost]
        public bool PhoneSil(TelModel id)
        {

            KY.KisiTelSil(id.TelId);
            return true;
        }
        [HttpPost]
        public bool EmailSil(EPostaModel  id)
        {

            KY.KisiEPostaSil(id.EPostaId);
            return true;
            
        }
    }
}
