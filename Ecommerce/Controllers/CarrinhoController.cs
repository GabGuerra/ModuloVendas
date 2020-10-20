using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Resultado;
using Ecommerce.Services.Carrinho;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ICarrinhoService _carrinhoService;
        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }
        public JsonResult AdicionarItem(int codProduto, int qtdProduto, string cpfUsuario)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            int? codCarrinhoCookie = Convert.ToInt32(Request.Cookies["codCarrinho"]);
            if (!codCarrinhoCookie.HasValue || codCarrinhoCookie == 0) 
            {
                resultado = _carrinhoService.CriarCarrinho(cpfUsuario);
                codCarrinhoCookie = Convert.ToInt32(resultado.ObjResultado);
                Response.Cookies.Append("codCarrinho", codCarrinhoCookie.ToString());                
            }
            _carrinhoService.AdicionarItem(codProduto, qtdProduto, codCarrinhoCookie.Value);

            return Json(resultado);
        }

        public IActionResult DetalheCarrinho() 
        {
            return View(_carrinhoService.CarregarDetalheCarrinho(Convert.ToInt32(Request.Cookies["codCarrinho"])));
        }
    }
}