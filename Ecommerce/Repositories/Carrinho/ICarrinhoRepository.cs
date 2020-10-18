using Ecommerce.Models.Carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Carrinho
{
    interface ICarrinhoRepository
    {
        public void AdicionarItem(CarrinhoItemVD item);
        public void RemoverItem(int codProduto);
    }
}
