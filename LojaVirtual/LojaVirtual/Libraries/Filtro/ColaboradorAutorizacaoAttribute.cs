using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using LojaVirtual.Models.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Libraries.Filtro
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginColaborador _loginColaborador;
        string _tipoColaboradorAutorizado;

        public ColaboradorAutorizacaoAttribute(string tipoColaboradorAutorizado = ColaboradorTipoConstant.Comum)
        {
            _tipoColaboradorAutorizado = tipoColaboradorAutorizado;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));
            Colaborador colaboradorLogin = _loginColaborador.GetColaborador();

            if (colaboradorLogin == null || colaboradorLogin.Id == 0)
                context.Result = new RedirectToActionResult(nameof(Login), "Home", null);
            else if (_tipoColaboradorAutorizado.Equals(ColaboradorTipoConstant.Gerente) && colaboradorLogin.Tipo.Equals(ColaboradorTipoConstant.Comum))
                context.Result = new ForbidResult();
        }
    }
}
