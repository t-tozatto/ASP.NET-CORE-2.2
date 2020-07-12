using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Libraries.Filtro
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string referer = context.HttpContext.Request.Headers["Referer"].ToString();

            if (string.IsNullOrWhiteSpace(referer))
                context.Result = new ContentResult()
                {
                    Content = "Acesso Negado!",
                };
            else
            {
                string hostReferer = new Uri(referer).Host;
                string hostServidor = context.HttpContext.Request.Host.Host;

                if(!hostReferer.Equals(hostServidor))
                    context.Result = new ContentResult()
                    {
                        Content = "Acesso Negado!",
                    };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
