using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class CategoriaController : Controller
    {
        ICategoriaRepository _categoriaRepository;
        
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index(int? pagina)
        {
            return View(_categoriaRepository.ObterTodasCategorias(pagina));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select( x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                _categoriaRepository.Cadastrar(categoria);
                TempData["MSG_S"] = "Registro salvo com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Where(x => x.Id != id).Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View(_categoriaRepository.ObterCategoria(id));
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                _categoriaRepository.Atualizar(categoria);
                TempData["MSG_S"] = "Registro atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Where(x => x.Id != categoria.Id).Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _categoriaRepository.Excluir(id);
            TempData["MSG_S"] = "Registro excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}
