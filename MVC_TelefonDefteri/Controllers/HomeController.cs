using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using MVC_TelefonDefteri.Entities;

namespace MVC_TelefonDefteri.Controllers
{
    public class HomeController : Controller
    {
        KisiYoneticisi KY = new KisiYoneticisi();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Anasayfa";
            Int16 Sayfa;

            #region Sayfa Numarasi Alma
            if (Request.QueryString["P"] ==null)
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

        public ActionResult Detail(int K)
        {
            
            return View(KY.GetirKisiler(K));
        }
        public ActionResult GetImg(int id)
        {
            byte[] image = KY.GetirKisiler(id).Photo;

            try
            {
                FileContentResult fds;
                if (image!=null)
                {
                    fds = File(image, "image/jpg");
                }
                else
                {
                    ImageToByte CTB = new ImageToByte();
                    string imagespath = Server.MapPath(HttpRuntime.AppDomainAppVirtualPath+"/images/noimage.jpg");
                    image = CTB.imageToByteArray(Image.FromFile(imagespath));
                    fds = File(image, "image/jpg");
                    
                }
                return fds;
            }
            catch (Exception)
            {

                ImageToByte CTB = new ImageToByte();
                string imagespath = Server.MapPath("images/noimage.jpg");
                image = CTB.imageToByteArray(Image.FromFile(imagespath));
                FileContentResult fds = File(image, "image/jpg");
                return fds;
            }



        }

        public ActionResult Ornek()
        {
            return View();
        }

        
    }
}