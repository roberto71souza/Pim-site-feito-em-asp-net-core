using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContabilyContextWebSite.Models;
using System.Net.Mail;
using ContabilyContextWebSite.Extension;

namespace ContabilyContextWebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Email email)
        {
            string _email = email._Email;
            string subject = $"Contato de {email.Nome} para informacoes de servico";
            string mensagem = $"Nome: {email.Nome} \nTelefone: {email.Telefone} \nEmail:{_email} \nMensagem: {email.Mensagem}";

            if (email.CamposValidos())
            {
                using (MailMessage mm = new MailMessage())
                {
                    mm.From = new MailAddress("contabilycontext@gmail.com");
                    mm.To.Add("contabilycontext@gmail.com");
                    mm.Subject = subject;
                    mm.Body = mensagem;
                    mm.IsBodyHtml = false;
/*                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("contabilycontext@gmail.com", "context1968");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mm);
                    }*/
                }
                TempData["Message"] = $"{email.Nome} seu email foi enviado com sucesso!!";
                return View("Index", email);
            }
            else
            {
                TempData["Message"] = "Os campos obrigatorios nao foram preenchidos";
                TempData["CampoInvalido"] = true;
            }
            return View("Index", email);
        }
    }
}
