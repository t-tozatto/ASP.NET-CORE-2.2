using LojaVirtual.Libraries.Arquivo;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao()]
    public class ProdutoController : Controller
    {
        IProdutoRepository _produtoRepository;
        ICategoriaRepository _categoriaRepository;
        IImagemRepository _imagemRepository;

        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository, IImagemRepository imagemRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _imagemRepository = imagemRepository;
        }

        public IActionResult Index(int? pagina, string pesquisa)
        {
            return View(_produtoRepository.ObterTodosProdutos(pagina, pesquisa));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Cadastrar(produto);
                _imagemRepository.CadastrarImagens(GerenciadorArquivo.MoverImagemProduto(Request.Form["imagem"].ToArray(), produto.Id.ToString()));

                TempData["MSG_S"] = Mensagem.MSG_S001;
                return RedirectToAction(nameof(Index));
            }
            produto.Imagens = new List<string>(Request.Form["imagem"]).Where(x => x.Trim().Length > 0).Select(x => new Imagem() { Caminho = x }).ToList();
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View(produto);
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View(_produtoRepository.ObterProduto(id));
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Atualizar(produto);
                _imagemRepository.ExcluirImagensProduto(produto.Id);
                _imagemRepository.CadastrarImagens(GerenciadorArquivo.MoverImagemProduto(Request.Form["imagem"].ToArray(), produto.Id.ToString()));

                TempData["MSG_S"] = Mensagem.MSG_S001;
                return RedirectToAction(nameof(Index));
            }
            produto.Imagens = new List<string>(Request.Form["imagem"]).Where(x => x.Trim().Length > 0).Select(x => new Imagem() { Caminho = x }).ToList();
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View(produto);
        }

        [HttpGet]
        [ValidateHttpReferer]
        public IActionResult Excluir(int id)
        {
            GerenciadorArquivo.ExcluirImagensProduto(id);
            _imagemRepository.ExcluirImagensProduto(id);
            _produtoRepository.Excluir(id);
            TempData["MSG_S"] = Mensagem.MSG_S003;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Voltar()
        {
            string[] caminhosImagens = Request.Form["imagem"].ToArray();

            for (int i = 0; i < caminhosImagens.Length; i++)
            {
                if (caminhosImagens[i].Contains("temp"))
                    GerenciadorArquivo.ExcluirImagemProduto(caminhosImagens[i]);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
