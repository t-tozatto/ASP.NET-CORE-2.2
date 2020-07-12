using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Libraries.Texto;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ColaboradorController : Controller
    {
        IColaboradorRepository _colaboradorRepository;
        GerenciarEmail _gerenciarEmail;

        public ColaboradorController(IColaboradorRepository colaboradorRepository, GerenciarEmail gerenciarEmail)
        {
            _colaboradorRepository = colaboradorRepository;
            _gerenciarEmail = gerenciarEmail;
        }

        public IActionResult Index(int? pagina)
        {
            return View(_colaboradorRepository.ObterTodosColaboradores(pagina));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Models.Colaborador colaborador)
        {
            if(ModelState.IsValid)
            {
                colaborador.Tipo = "C";
                colaborador.Senha = KeyGenerator.GetUniqueKey(8);
                _colaboradorRepository.Cadastrar(colaborador);
                _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);
                TempData["MSG_S"] = Mensagem.MSG_S001;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult GerarSenha(int id)
        {
            Models.Colaborador colaborador = _colaboradorRepository.ObterColaborador(id);
            colaborador.Senha = KeyGenerator.GetUniqueKey(8);
            _colaboradorRepository.Atualizar(colaborador);
            _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);
            TempData["MSG_S"] = Mensagem.MSG_S004;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            return View(_colaboradorRepository.ObterColaborador(id));
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Models.Colaborador colaborador)
        {
            if(ModelState.IsValid)
            {
                _colaboradorRepository.Atualizar(colaborador);
                TempData["MSG_S"] = Mensagem.MSG_S002;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _colaboradorRepository.Excluir(id);
            TempData["MSG_S"] = Mensagem.MSG_S003;
            return RedirectToAction(nameof(Index));
        }
    }
}
