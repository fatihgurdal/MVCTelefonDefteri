using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TelefonDefteri.Entities
{
    [Table("Kisiler")]
    public class Kisi
    {
        public Kisi()
        {
            this.Telefonlar = new HashSet<Telefon>();
            this.EPostalar = new HashSet<EPosta>();
        }
        [Key,DisplayName("Kişi ID")]
        public int Id { get; set; }
        [MaxLength(50), Required, DisplayName("Adı")]
        public string Adi { get; set; }
        [MaxLength(50), Required, DisplayName("Soyadı")]
        public string Soyad { get; set; }
        [DisplayName("Aktif Mi?")]
        public bool AktifMi { get; set; }
        [DisplayName("Doğum Tarihi"),DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DogumTarihi { get; set; }
        [MaxLength(150), DisplayName("Açıklama")] 
        public string Aciklama { get; set; }
        [Column(TypeName = "image"), DisplayName("Profil Resmi")]
        public byte[] Photo { get; set; }
        [UIHint("TelefonlarTemp"),DisplayName("Telefon Numaraları")]
        public virtual ICollection<Telefon> Telefonlar { get; set; }
        [UIHint("EPostalarTemp"), DisplayName("E-Posta Adresleri")]
        public virtual ICollection<EPosta> EPostalar { get; set; }
    }
}
