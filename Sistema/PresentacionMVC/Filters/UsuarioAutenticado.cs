using PresentacionMVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentacionMVC.Filters
{
    public class UsuarioAutenticado : Attribute, IActionFilter
    {
        //DESPUES
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        //ANTES
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!Autenticacion.EsUsuarioAutenticado(context.HttpContext))
            {
                context.Result = new RedirectResult("/Usuario/Login");
            }
                
        }
    }
}
