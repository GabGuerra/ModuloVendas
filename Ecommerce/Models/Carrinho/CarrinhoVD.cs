using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Carrinho
{
    public class CarrinhoVD
    {
        public int CodCarrinho { get; set; }
        public List<CarrinhoItemVD> ListaItens { get; set; }
    }
}
