﻿using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Visualizar()
        {
            Produto produto = GetProduto();
            return View(produto);
        }

        public Produto GetProduto()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Xbox One X",
                Descricao = "Jogue em 4K",
                Valor = 2000.00
            };
        }
    }
}
