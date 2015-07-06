using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using MVC_TelefonDefteri.Entities;

namespace MVC_TelefonDefteri.Methods
{
    public static class KullaniciIslem
    {
        public static bool GirisOnay(Kullanici K)
        {
            KullaniciYonetimi KY = new KullaniciYonetimi();
            if (K != null)
            {
                if (KY.KullaniciVarMi(K))
                {
                    return true;
                }
                else
                {
                    
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
    }
}