using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Models.Constants;
using LojaVirtual.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private LojaVirtualContext _banco;
        IConfiguration _configuration;

        public ColaboradorRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _configuration = configuration;
        }

        public Colaborador Login(string Email, string Senha)
        {
            return _banco.Colaboradores.Where(x => x.Email.Equals(Email) && x.Senha.Equals(Senha)).FirstOrDefault();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Atualizar(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.Entry(colaborador).Property(x => x.Senha).IsModified = false;
            _banco.SaveChanges();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.Entry(colaborador).Property(x => x.Nome).IsModified = false;
            _banco.Entry(colaborador).Property(x => x.Email).IsModified = false;
            _banco.Entry(colaborador).Property(x => x.Tipo).IsModified = false;
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            _banco.Remove(ObterColaborador(Id));
            _banco.SaveChanges();
        }

        public Colaborador ObterColaborador(int Id)
        {
            return _banco.Colaboradores.Find(Id);
        }

        public IPagedList<Colaborador> ObterTodosColaboradores(int? pagina)
        {
            return _banco.Colaboradores.Where(x => !x.Tipo.Equals(ColaboradorTipoConstant.Gerente)).OrderBy(x => x.Nome).ToPagedList(pagina ?? 1, _configuration.GetValue<int>("RegistrosPorPagina"));
        }

        public int ObterColaboradorPorEmaill(string email, int id)
        {
            return _banco.Colaboradores.Where(x => x.Email.Equals(email) && !x.Id.Equals(id)).Count();
        }
    }
}
