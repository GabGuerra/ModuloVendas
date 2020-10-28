using Ecommerce.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Carrinho
{
    public class CarrinhoItemVD
    {
        public ProdutoVD Produto { get; set; }
        public int QtdProduto { get; set; }

        public CarrinhoItemVD()
        {
            Produto = new ProdutoVD();
        }
        public CarrinhoItemVD(int codProduto, int qtdProduto)
        {
            Produto = new ProdutoVD(codProduto);
            QtdProduto = qtdProduto;
        }
        public CarrinhoItemVD(ProdutoVD produto, int qtdProduto)
        {
            Produto = produto;
            QtdProduto = qtdProduto;
        }
    }
}
