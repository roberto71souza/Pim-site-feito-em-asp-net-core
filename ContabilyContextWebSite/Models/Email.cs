using ContabilyContextWebSite.Extension;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ContabilyContextWebSite.Models
{
    public class Email
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string _Email { get; set; }
        public string Mensagem { get; set; }

        public static async Task<bool> Enviar(Email email)
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
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("contabilycontext@gmail.com", "context1968");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mm);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
