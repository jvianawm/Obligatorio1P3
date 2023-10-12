using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentacionMVC.Helpers
{
    public static class Autenticacion
    {
        public static bool EsUsuarioAutenticado(HttpContext context)
        {
            return !string.IsNullOrEmpty(context.Session.GetString("ALIAS"));
        }

        public static bool EsSuperUsuario(HttpContext context)
        {
            string? alias = context.Session.GetString("ALIAS");
            return !string.IsNullOrEmpty(alias) && alias.ToUpper() == "ADMIN1";
        }
    }
}
