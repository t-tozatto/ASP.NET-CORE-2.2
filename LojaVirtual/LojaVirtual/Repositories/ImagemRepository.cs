using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private LojaVirtualContext _banco;

        public ImagemRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(Imagem imagem)
        {
            _banco.Add(imagem);
            _banco.SaveChanges();
        }

        public void CadastrarImagens(List<Imagem> listaImagens)
        {
            if (listaImagens.Count > 0)
            {
                foreach (Imagem imagem in listaImagens)
                    _banco.Add(imagem);

                _banco.SaveChanges();
            }
        }

        public void Excluir(int Id)
        {
            _banco.Remove(_banco.Imagens.Find(Id));
            _banco.SaveChanges();
        }

        public void ExcluirImagensProduto(int ProdutoId)
        {
            _banco.RemoveRange(_banco.Imagens.Where(x => x.ProdutoId.Equals(ProdutoId)));
            _banco.SaveChanges();
        }
    }
}
