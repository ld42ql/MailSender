using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.Test.Models
{
   public class TextMail
    {
      private  string subject;
      private  string body;

        public string Body { get => body; set => body = value; }
        public string Subject { get => subject; set => subject = value; }
    }
}
