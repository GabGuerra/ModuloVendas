using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Models.Carrinho;
using Ecommerce.Models.Resultado;
using Ecommerce.Services.Carrinho;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ICarrinhoService _carrinhoService;
        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }
        public JsonResult AdicionarItem(int codProduto, int qtdProduto, string cpfUsuario, int codDeposito)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            int? codCarrinhoCookie = Convert.ToInt32(Request.Cookies["codCarrinho"]);
            if (!codCarrinhoCookie.HasValue || codCarrinhoCookie == 0) 
            {
                resultado = _carrinhoService.CriarCarrinho(cpfUsuario);
                codCarrinhoCookie = Convert.ToInt32(resultado.Resultado);
                Response.Cookies.Append("codCarrinho", codCarrinhoCookie.ToString());                
            }
            resultado = _carrinhoService.AdicionarItem(codProduto, qtdProduto, codCarrinhoCookie.Value, cpfUsuario, codDeposito).Result;

            return Json(resultado);
        }

        public JsonResult CancelarCarrinho(int codCarrinho)
        {
            return Json(_carrinhoService.CancelarCarrinho(Convert.ToInt32(Request.Cookies["codCarrinho"])));
        }

        public IActionResult DetalheCarrinho() 
        {
            return View(_carrinhoService.CarregarDetalheCarrinho(Convert.ToInt32(Request.Cookies["codCarrinho"])));
        }

        [HttpPost]
        public JsonResult FinalizarCompra(string carrinho) 
        {
            var usuario = JsonConvert.DeserializeObject<UsuarioVD>(HttpContext.Session.GetString("usuarioLogado"));
            //carrinho.CpfUsuario = usuario.Cpf;
            //return Json(_carrinhoService.FinalizarCompra(carrinho));
            return Json("");
        }
    }
}