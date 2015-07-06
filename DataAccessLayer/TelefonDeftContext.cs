using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_TelefonDefteri.Entities;

namespace DataAccessLayer
{
    public class TelefonDeftContext:DbContext
    {
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<EPosta> Epostalar { get; set; }
        public DbSet<Telefon> Telefonlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        public TelefonDeftContext()
        {
            Database.SetInitializer<TelefonDeftContext>(new MyInitializer());
        }
    }

    public class MyInitializer : CreateDatabaseIfNotExists<TelefonDeftContext>
    {
        protected override void Seed(TelefonDeftContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                Kisi K1 = new Kisi()
                {
                    Adi = FakeData.NameData.GetFirstName(),
                    Soyad = FakeData.NameData.GetSurname(),
                    AktifMi = true,
                    DogumTarihi = FakeData.DateTimeData.GetDatetime()

                };
                for (int j = 0; j < 3; j++)
                {
                    EPosta EP = new EPosta(){
                        Adres=FakeData.NetworkData.GetEmail(),
                        BirincilMi=(j==0)?true:false                        
                    };
                    K1.EPostalar.Add(EP);
                }
                for (int x = 0; x < 3; x++)
                {
                    Telefon Tel = new Telefon(){
                        No=FakeData.NumberData.GetNumber().ToString(),
                        BirincilMi=(x==0)?true:false
                    };
                    K1.Telefonlar.Add(Tel);
                }
                context.Kisiler.Add(K1);
            }
            context.Kullanicilar.Add(new Kullanici() { 
                KullaniciAdi="Admin",
                KullaniciSifre="123456"
            });
            context.SaveChanges();
        }
    }
}
