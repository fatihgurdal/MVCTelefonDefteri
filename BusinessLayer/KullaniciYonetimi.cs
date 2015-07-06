using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_TelefonDefteri.Entities;
using DataAccessLayer;

namespace BusinessLayer
{
    public class KullaniciYonetimi
    {
        Repository<Kullanici> Rep;
        public KullaniciYonetimi()
        {
            this.Rep = new Repository<Kullanici>();
        }
        
        public bool KullaniciVarMi(Kullanici K)
        {
            int TK = Rep.Count(x => x.KullaniciAdi == K.KullaniciAdi && x.KullaniciSifre == K.KullaniciSifre);
            if (TK>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Kullanici KullaniciGetir(Kullanici K)
        {
            Kullanici TK = Rep.First(x => x.KullaniciAdi == K.KullaniciAdi && x.KullaniciSifre == K.KullaniciSifre);

            return TK;
        }
    }
}
