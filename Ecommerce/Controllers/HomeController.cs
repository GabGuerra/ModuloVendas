using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Services.Categoria;
using Ecommerce.Services.Produto;
using Ecommerce.Models.Vitrine;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoriaService _categoriaService;
        private readonly IProdutoService _produtoService;
        public HomeController(ICategoriaService categoriaService, IProdutoService produtoService)
        {
            _categoriaService = categoriaService;
            _produtoService = produtoService;
        }

        public IActionResult Vitrine()
        {
            return View(new VitrineVD(_produtoService.ListarProdutos(), _categoriaService.ListarCategorias(), _produtoService.ListarProdutosRecomendados()));
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
