using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private LojaVirtualContext _banco;
        IConfiguration _configuration;

        public ClienteRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _configuration = configuration;
        }

        public void Atualizar(Cliente cliente)
        {
            _banco.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _banco.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            _banco.Remove(ObterCliente(Id));
            _banco.SaveChanges();
        }

        public Cliente Login(string Email, string Senha)
        {
            return _banco.Clientes.Where(x => x.Email.Equals(Email) && x.Senha.Equals(Senha)).FirstOrDefault();
        }

        public Cliente ObterCliente(int Id)
        {
            return _banco.Clientes.Find(Id);
        }

        public IPagedList<Cliente> ObterTodosClientes(int? pagina, string pesquisa = "")
        {
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                pesquisa = pesquisa.Trim();
                return _banco.Clientes.Where(x => x.Nome.Contains(pesquisa) || x.Email.Contains(pesquisa)).OrderBy(x => x.Nome).ToPagedList(pagina ?? 1, _configuration.GetValue<int>("RegistrosPorPagina"));
            }

            return _banco.Clientes.OrderBy(x => x.Nome).ToPagedList(pagina ?? 1, _configuration.GetValue<int>("RegistrosPorPagina"));
        }
    }
}
