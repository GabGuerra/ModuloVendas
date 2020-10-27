using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Movimentacao
{
    public class ProdutoMovimentacao
    {
        public int CodProduto { get; set; }
        public ProdutoMovimentacao(int codProduto)
        {
            CodProduto = codProduto;
        }
        public ProdutoMovimentacao()
        {

        }
    }
}
