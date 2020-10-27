using Ecommerce.Models.Carrinho;
using Ecommerce.Models.Resultado;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Carrinho
{
    public interface ICarrinhoService
    {
        public ResultadoVD CriarCarrinho(string cpfUsuario);
        public Task<ResultadoVD> AdicionarItem(int codProduto, int qtdAdicionar, int codCarrinho, string cpfUsuario, int codDeposito);
        public ResultadoVD RemoverItem(int codProduto, int qtdRemover, int codCarrinho);

        public CarrinhoVD CarregarDetalheCarrinho(int codCarrinho);
    }
}
