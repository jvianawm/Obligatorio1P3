using PresentacionMVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PresentacionMVC.Filters
{
    public class SuperUsuario : Attribute, IActionFilter
    {
        //DESPUES
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        //ANTES
        public void OnActionExecuting(ActionExecutingContext context)
        {          
            if (!Autenticacion.EsSuperUsuario(context.HttpContext))
            {
                context.Result = new RedirectResult("/Home");
            }                
        }
    }
}
