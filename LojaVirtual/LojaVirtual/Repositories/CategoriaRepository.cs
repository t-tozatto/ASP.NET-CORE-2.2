using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        LojaVirtualContext _banco;
        IConfiguration _configuration;

        public CategoriaRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _configuration = configuration;
        }

        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            _banco.Remove(ObterCategoria(Id));
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int Id)
        {
            return _banco.Categorias.Find(Id);
        }

        public IPagedList<Categoria> ObterTodasCategorias(int? pagina)
        {
            return _banco.Categorias.Include(x => x.CategoriaPai).OrderBy(x => x.Nome).ToPagedList(pagina ?? 1, _configuration.GetValue<int>("RegistrosPorPagina"));
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return _banco.Categorias.OrderBy(x => x.Nome);
        }
    }
}
