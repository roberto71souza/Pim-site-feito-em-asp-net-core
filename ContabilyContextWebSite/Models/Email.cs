using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilyContextWebSite.Models
{
    public class Email
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string _Email { get; set; }
        public string Mensagem { get; set; }
    }
}
