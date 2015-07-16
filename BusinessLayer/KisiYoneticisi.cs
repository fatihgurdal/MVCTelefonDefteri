using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MVC_TelefonDefteri.Entities;

namespace BusinessLayer
{
    public class KisiYoneticisi
    {
        Repository<Kisi> Rep = new Repository<Kisi>();
        Repository<EPosta> RepEposta = new Repository<EPosta>();
        Repository<Telefon> RepTel = new Repository<Telefon>();
        public byte Adet { get; set; }
        public KisiYoneticisi()
        {
            this.Adet = 3;
        }
        public List<Kisi> GetirKisiler(Int16 Sayfa)
        {
            if (Sayfa < 1)
            {
                Sayfa = 1;
            }


            int Atla = (Sayfa - 1) * this.Adet;
            List<Kisi> Liste = SM.DB.Kisiler.Where(x=>x.AktifMi==true).OrderByDescending(x => x.Id).Skip(Atla).Take(Adet).ToList();

            return Liste;
        }
        public Kisi GetirKisiler(int Id)
        {
            return Rep.First(x => x.Id == Id);
        }

        public int SayfaSayisi(Int16 Sayfa)
        {
            int ToplamVeri = SM.DB.Kisiler.Count();
            int SayfaAdeti = 0;
            SayfaAdeti = ToplamVeri / this.Adet;
            if (ToplamVeri % this.Adet>0)
            {
                SayfaAdeti += 1;
            }
            
            return SayfaAdeti;
        }
        public void KisiEkle(Kisi K1)
        {
            Rep.Add(K1);
        }
        public void KisiEPostaSil(int EpostaId)
        {
            RepEposta.Delete(EpostaGetir(EpostaId));
            Rep.UpdateSaveChanges();
        }
        public EPosta EpostaGetir(int Id)
        {
            return RepEposta.First(x => x.Id == Id);
        }

        public void KisiTelSil(int TelId)
        {
            RepTel.Delete(TelGetir(TelId));
            Rep.UpdateSaveChanges();
        }

        private Telefon TelGetir(int Id)
        {
            return RepTel.First(x => x.Id == Id);
        }
        public Telefon TelEkle(string StrTel,int KulId)
        {
            Kisi K = GetirKisiler(KulId);
            Telefon Tel = new Telefon
            {
                No = StrTel
            };
            K.Telefonlar.Add(Tel);
            Rep.UpdateSaveChanges();

            return Tel;
        }
        public EPosta EPostaEkle(string StrEPosta, int KulId)
        {
            Kisi K = GetirKisiler(KulId);
            EPosta EP = new EPosta
            {
                Adres = StrEPosta
            };
            K.EPostalar.Add(EP);
            Rep.UpdateSaveChanges();

            return EP;
        }
        
        public Kisi KisiGuncelle(Kisi collection, byte[] ImageUpload)
        {
            Kisi K = GetirKisiler(collection.Id);
            K.Aciklama = collection.Aciklama;
            K.Adi = collection.Adi;
            K.AktifMi = collection.AktifMi;
            K.DogumTarihi = collection.DogumTarihi;
            K.Soyad = collection.Soyad;

            if (ImageUpload!=null)
            {
                K.Photo = ImageUpload;                
            }

            Rep.UpdateSaveChanges();
            return K;
        }

        public void KisiSil(int id)
        {
            Kisi K = Rep.First(x => x.Id == id);
            Rep.Delete(K);
        }
    }
}
