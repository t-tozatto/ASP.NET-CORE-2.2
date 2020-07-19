using LojaVirtual.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace LojaVirtual.Libraries.Arquivo
{
    public class GerenciadorArquivo
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            string nomeArquivo = Path.GetFileName(file.FileName);

            using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", nomeArquivo), FileMode.Create))
                file.CopyTo(stream);

            return Path.Combine("/uploads/temp", nomeArquivo).Replace("\\", "/");
        }

        public static bool ExcluirImagemProduto(string caminho)
        {
            string Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminho.Trim('/')).Replace("/", "\\");
            
            if(File.Exists(Caminho))
            {
                File.Delete(Caminho);
                return true;
            }
            return false;
        }

        public static void ExcluirImagensProduto(int idProduto)
        {
            string Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\produtos\\", idProduto.ToString());

            DirectoryInfo di = new DirectoryInfo(Caminho);

            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            Directory.Delete(Caminho);
        }

        public static List<Imagem> MoverImagemProduto(string[] caminhos, string produtoId)
        {
            string diretorioAtualProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/produtos/", produtoId);
            
            if(!Directory.Exists(diretorioAtualProduto))
                Directory.CreateDirectory(diretorioAtualProduto);

            string caminhoTemp = string.Empty, caminhoDefinitivo = string.Empty, nomeArquivo = string.Empty;
            List<Imagem> listaNomeArquivos = new List<Imagem>();
            for(int i = 0; i < caminhos.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(caminhos[i]))
                {
                    nomeArquivo = Path.GetFileName(caminhos[i]);
                    caminhoTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", nomeArquivo);
                    caminhoDefinitivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/produtos/", produtoId, nomeArquivo);
                    if (!string.Concat(Directory.GetCurrentDirectory(), @"\wwwroot", caminhos[i].Replace("/", "\\")).Equals(caminhoDefinitivo.Replace("/", "\\")))
                    {
                        if (File.Exists(caminhoTemp))
                        {
                            if(!File.Exists(caminhoDefinitivo))
                                File.Copy(caminhoTemp, caminhoDefinitivo);

                            if (File.Exists(caminhoDefinitivo))
                            {
                                File.Delete(caminhoTemp);
                                listaNomeArquivos.Add(new Imagem()
                                {
                                    Caminho = Path.Combine("/uploads/produtos", produtoId, nomeArquivo).Replace("\\", "/"),
                                    ProdutoId = Convert.ToInt32(produtoId),
                                });
                            }
                        }
                    }
                    else
                        listaNomeArquivos.Add(new Imagem()
                        {
                            Caminho = Path.Combine("/uploads/produtos", produtoId, nomeArquivo).Replace("\\", "/"),
                            ProdutoId = Convert.ToInt32(produtoId),
                        });
                }
            }
            return listaNomeArquivos;
        }
    }
}
