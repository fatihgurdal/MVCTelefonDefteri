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
    [Table("Telefonlar")]
    public class Telefon
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required,DisplayName("Numara")]
        public string No { get; set; }
        public bool BirincilMi { get; set; }

        public Kisi Kisi { get; set; }
    }
}
