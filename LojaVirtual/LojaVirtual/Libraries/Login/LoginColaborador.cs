using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private Sessao.Sessao _sessao;
        private string Key = "Login.Colaborador";

        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            _sessao.Cadastrar(Key, JsonConvert.SerializeObject(colaborador));
        }

        public Colaborador GetColaborador()
        {
            string colaborador = _sessao.Consultar(Key);

            if (!string.IsNullOrWhiteSpace(colaborador))
                return JsonConvert.DeserializeObject<Colaborador>(colaborador);
            else
                return null;
        }

        public void Logout()
        {
            _sessao.RemoverTodas();
        }
    }
}
