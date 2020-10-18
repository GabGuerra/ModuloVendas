using Ecommerce.Models.Carrinho;
using Ecommerce.Repositories.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Carrinho
{
    public class CarrinhoRepository : DbRepository<CarrinhoVD>, ICarrinhoRepository
    {
        public CarrinhoRepository(IConfiguration config) : base(config) { }

        public void AdicionarItem(CarrinhoItemVD item)
        {
            throw new NotImplementedException();
        }

        public void RemoverItem(int codProduto)
        {
            throw new NotImplementedException();
        }
    }
}
