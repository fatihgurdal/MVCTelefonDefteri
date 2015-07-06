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
    [Table("EPostalar")]
    public class EPosta
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required,DisplayName("E-Posta")]
        public string Adres { get; set; }

        public bool BirincilMi { get; set; }

        public Kisi Kisi { get; set; }
    }
}
