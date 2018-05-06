using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.Implementation.Models
{
   public class StatusMessadge
    {
        private string status;
        private string email;
        private DateTime date;

        public DateTime Date { get => date; set => date = value; }
        public string Email { get => email; set => email = value; }
        public string Status { get => status; set => status = value; }
    }
}
