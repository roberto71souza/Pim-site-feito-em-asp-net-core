using ContabilyContextWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilyContextWebSite.Extension
{
    public static class Validacao
    {
        public static bool CamposValidos(this Email obj)
        {
            var nome = string.IsNullOrWhiteSpace(obj.Nome);
            var email = string.IsNullOrWhiteSpace(obj._Email);
            var mensagem = string.IsNullOrWhiteSpace(obj.Mensagem);

            if (nome || email || mensagem)
            {
                return false;
            }
            return true;
        }
    }
}
