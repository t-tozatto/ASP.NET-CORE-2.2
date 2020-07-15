using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Models;
using LojaVirtual.Models.Constants;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ClienteController : Controller
    {
        IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index(int? pagina, string pesquisa = "")
        {
            return View(_clienteRepository.ObterTodosClientes(pagina, pesquisa));
        }

        [ValidateHttpReferer]
        public IActionResult AtivarDesativar(int id)
        {
            Cliente cliente = _clienteRepository.ObterCliente(id);
            cliente.Situacao = cliente.Situacao.Equals(SituacaoConstant.Ativo) ? SituacaoConstant.Desativo : SituacaoConstant.Ativo;
            _clienteRepository.Atualizar(cliente);

            TempData["MSG_S"] = Mensagem.MSG_S002;

            return RedirectToAction(nameof(Index));
        }
    }
}
