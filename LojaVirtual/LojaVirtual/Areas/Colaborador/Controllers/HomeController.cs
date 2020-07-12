using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private IColaboradorRepository _repositoryColaborador;
        private LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository colaboradorRepository, LoginColaborador loginColaborador)
        {
            _repositoryColaborador = colaboradorRepository;
            _loginColaborador = loginColaborador;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Models.Colaborador colaborador)
        {
            Models.Colaborador colaboradorLogin = _repositoryColaborador.Login(colaborador.Email, colaborador.Senha);
            if (colaboradorLogin != null && colaboradorLogin.Id > 0)
            {
                _loginColaborador.Login(colaboradorLogin);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário não encontrado, verifique e-mail e senha!";
                return View();
            }
        }
        [ColaboradorAutorizacao]
        public IActionResult Painel()
        {
            return View();
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }

        public IActionResult CadastrarSenha()
        {
            return View();
        }

        [ColaboradorAutorizacao]
        [ValidateHttpReferer]
        public IActionResult Logout()
        {
            _loginColaborador.Logout();
            return RedirectToAction(nameof(Login), "Home");
        }
    }
}