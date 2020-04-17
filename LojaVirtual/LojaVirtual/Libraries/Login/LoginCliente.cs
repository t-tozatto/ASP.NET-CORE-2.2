using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private Sessao.Sessao _sessao;
        private string Key = "Login.Cliente";

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            _sessao.Cadastrar(Key, JsonConvert.SerializeObject(cliente));
        }

        public Cliente GetCliente()
        {
            string cliente = _sessao.Consultar(Key);

            if (!string.IsNullOrWhiteSpace(cliente))
                return JsonConvert.DeserializeObject<Cliente>(cliente);
            else 
                return null;
        }

        public void Logout()
        {
            _sessao.RemoverTodas();
        }
    }
}
