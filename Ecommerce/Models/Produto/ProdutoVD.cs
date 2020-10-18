using Ecommerce.Models.Categoria;
using Ecommerce.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Produto
{
    public class ProdutoVD
    {
        public int? CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public double? PrecoCustoMedio { get; set; }        
        public double PrecoVenda { get => PrecoCustoMedio.Value + PrecoCustoMedio.Value * 0.15; set { } }
        public string CaminhoImagem { get; set; }

        public FornecedorVD Fornecedor { get; set; }
        public CategoriaVD Categoria { get; set; } 
        public ProdutoVD()
        {            
            Fornecedor = new FornecedorVD();
        }
        public ProdutoVD(string NomeProduto)
        {
        }
        public ProdutoVD(int? codProduto, string nomeProduto, double? precoCustoMedio,string caminhoImagem, FornecedorVD fornecedor, CategoriaVD categoria)
        {
            CodProduto = CodProduto;
            NomeProduto = nomeProduto;
            PrecoCustoMedio = precoCustoMedio;
            CaminhoImagem = caminhoImagem;
            Fornecedor = fornecedor;
            Categoria = categoria;
        }
    }
}
