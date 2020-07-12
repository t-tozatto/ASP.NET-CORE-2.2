using LojaVirtual.Models;
using X.PagedList;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string Email, string Senha);

        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void AtualizarSenha(Colaborador colaborador);
        void Excluir(int Id);

        Colaborador ObterColaborador(int Id);
        int ObterColaboradorPorEmaill(string email, int id);
        IPagedList<Colaborador> ObterTodosColaboradores(int? pagina);
    }
}
