using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private LojaVirtualContext _banco;
        IConfiguration _configuration;

        public ProdutoRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _configuration = configuration;
        }

        public void Atualizar(Produto produto)
        {
            _banco.Update(produto);
            _banco.SaveChanges();
        }

        public void Cadastrar(Produto produto)
        {
            _banco.Add(produto);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            _banco.Remove(ObterProduto(Id));
            _banco.SaveChanges();
        }

        public Produto ObterProduto(int Id)
        {
            return _banco.Produtos.Include(x => x.Imagens).Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public IPagedList<Produto> ObterTodosProdutos(int? pagina, string pesquisa)
        {
            if (!string.IsNullOrEmpty(pesquisa))
                return _banco.Produtos.Where(x => x.Nome.Contains(pesquisa.Trim())).OrderBy(x => x.Nome).ToPagedList(pagina ?? 1, _configuration.GetValue<int>("RegistrosPorPagina"));

            return _banco.Produtos.Include(x => x.Imagens).OrderBy(x => x.Nome).ToPagedList(pagina ?? 1, _configuration.GetValue<int>("RegistrosPorPagina"));
        }
    }
}
