using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private LojaVirtualContext _banco;
        public ColaboradorRepository(LojaVirtualContext banco)
        {
            _banco = banco;
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

        public List<Colaborador> ObterTodosColaboradores()
        {
            return _banco.Colaboradores.ToList();
        }
    }
}
