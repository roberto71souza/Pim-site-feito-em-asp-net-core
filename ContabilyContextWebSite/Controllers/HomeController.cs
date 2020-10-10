using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContabilyContextWebSite.Models;

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
            try
            {
                if (await Email.Enviar(email))
                {
                    TempData["Message"] = $"{email.Nome} seu email foi enviado com sucesso!!";
                }
                else
                {
                    TempData["Message"] = "Os campos obrigatorios nao foram preenchidos";
                    TempData["CampoInvalido"] = true;
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"erro ao enviar Email:\n {ex}";
                TempData["CampoInvalido"] = true;
            }
            return View("Index", email);
        }
    }
}
