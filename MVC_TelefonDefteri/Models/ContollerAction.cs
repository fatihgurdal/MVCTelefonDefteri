using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TelefonDefteri.Models
{
    public class ContollerAction
    {
        public string ContollerNames { get; set; }
        public string ActionNames { get; set; }
    }
    public class EmailModel
    {
        public string Email { get; set; }
        public int KisiId { get; set; }
    }

    public class PhoneModel
    {
        public string Phone { get; set; }
        public int KisiId { get; set; }
    }
}
