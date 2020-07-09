using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Libraries.Filtro
{
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            Cliente clienteLogin = _loginCliente.GetCliente();

            if (clienteLogin == null || clienteLogin.Id == 0)
            {
                context.Result = new ContentResult()
                {
                    Content = "Acesso Negado!"
                };
            }
        }
    }
}
