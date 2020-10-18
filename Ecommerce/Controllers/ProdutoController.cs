using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)            
        {
            _produtoService = produtoService;
        }
        public IActionResult DetalheProduto(int codProduto)
        {
            return View(_produtoService.CarregarDetalheProduto(codProduto));
        }
    }
}