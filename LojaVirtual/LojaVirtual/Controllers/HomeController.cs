using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _repositoryCliente;
        private INewsletterRepository _repositoryNewsletter;
        private LoginCliente _loginCliente;

        public HomeController(IClienteRepository repositoryCliente, INewsletterRepository newsletterRepository, LoginCliente loginCliente)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryNewsletter = newsletterRepository;
            _loginCliente = loginCliente;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsletterEmail newsletter)
        {
            if (ModelState.IsValid)
            {
                _repositoryNewsletter.Cadastrar(newsletter);

                TempData["MSG_S"] = "E-mail cadastrado! Agora você irá receber promoções especiais no seu e-mail! Fique atento as novidades!";

                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato()
                {
                    Nome = HttpContext.Request.Form["nome"],
                    Email = HttpContext.Request.Form["email"],
                    Texto = HttpContext.Request.Form["texto"]
                };

                List<ValidationResult> listaMensagens = new List<ValidationResult>();
                ValidationContext contexto = new ValidationContext(contato);

                if (Validator.TryValidateObject(contato, contexto, listaMensagens, true))
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviada com sucesso!";
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (ValidationResult validationResult in listaMensagens)
                    {
                        stringBuilder.Append(validationResult.ErrorMessage);
                        stringBuilder.Append("<br/>");
                        stringBuilder.Append("<br/>");
                    }

                    ViewData["MSG_E"] = stringBuilder.ToString();
                    ViewData["CONTATO"] = contato;
                }
            }
            catch(Exception)
            {
                ViewData["MSG_E"] = "Oops! Tivemos um erro, texte novamente mais terde!";
                //TODO - Implementar log
            }
            return View("Contato");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            Cliente clienteLogin =_repositoryCliente.Login(cliente.Email, cliente.Senha);
            if (clienteLogin != null && clienteLogin.Id > 0)
            {
                _loginCliente.Login(clienteLogin);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário não encontrado, verifique e-mail e senha!";
                return View();
            }
        }

        [HttpGet]
        [ClienteAutorizacao]
        public IActionResult Painel()
        {
            return new ContentResult()
            {
                Content = "Este é o painel do Cliente!"
            };
        }

        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm]Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _repositoryCliente.Cadastrar(cliente);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!";

                return RedirectToAction(nameof(CadastroCliente));
            }
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}