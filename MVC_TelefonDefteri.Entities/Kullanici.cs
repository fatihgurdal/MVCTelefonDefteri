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
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        [DisplayName("Kullanıcı ID")]
        public int KulId { get; set; }
        [MaxLength(50),Required]
        [DisplayName("Kullanıcı Adi")]
        public string KullaniciAdi { get; set; }
        [MaxLength(50),Required,DataType(DataType.Password)]
        [DisplayName("Kullanıcı Şifre")]
        public string KullaniciSifre { get; set; }
    }
}
