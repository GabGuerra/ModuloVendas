using Ecommerce.Models.Carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Carrinho
{
    public interface ICarrinhoRepository
    {
        public void AdicionarItem(CarrinhoItemVD item, int codCarrinho);
        public void RemoverItem(CarrinhoItemVD item, int codCarrinho);
        public int CriarCarrinho(string cpfUsuario);
        public CarrinhoVD CarregarDetalheCarrinho(int codCarrinho);
        public long InserirPedido(string cpfUsuario);
        public void InserirPedidoItem(CarrinhoItemVD item, long codPedido);
        public void LimparCarrinho(int codCarrinho);
    }
}
