using LojaVirtual.Libraries.Arquivo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ImagemController : Controller
    {
        [HttpPost]
        public IActionResult Armazenar(IFormFile file)
        {
            string Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);
            
            if(!string.IsNullOrWhiteSpace(Caminho))
                return Ok(new { caminho = Caminho });
            else
                return new StatusCodeResult(500);
        }

        public IActionResult Deletar(string caminho)
        {
            if (GerenciadorArquivo.ExcluirImagemProduto(caminho))
                return Ok();

            return BadRequest();
        }
    }
}
