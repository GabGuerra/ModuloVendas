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
        public int QtdDisponivel { get; set; }
        public string NomeProduto { get; set; }
        public string CaminhoImagemPrincipal { get; set; }
        public string DscProduto { get; set; }
        public double? PrecoCustoMedio { get; set; }
        public double PrecoVenda { get => PrecoCustoMedio.Value + PrecoCustoMedio.Value * 0.15; set { } } //Valor p/ calculo virá da base futuramente
        public bool IndProdutoEmDestaque { get; set; }
        public int CodDeposito { get; set; }
        public FornecedorVD Fornecedor { get; set; }
        public CategoriaVD Categoria { get; set; }
        public List<ImagemProdutoVD> ListaImagens { get; set; }
        public ProdutoVD()
        {
            Fornecedor = new FornecedorVD();
            Categoria = new CategoriaVD();
            ListaImagens = new List<ImagemProdutoVD>();
        }
        public ProdutoVD(int? codProduto)
        {
            CodProduto = codProduto;
        }
        public ProdutoVD(int? codProduto, string nomeProduto, double? precoCustoMedio, string caminhoImagemPrincipal, int codDeposito)
        {
            CodProduto = codProduto;
            NomeProduto = nomeProduto;
            PrecoCustoMedio = precoCustoMedio;
            CaminhoImagemPrincipal = caminhoImagemPrincipal;
            CodDeposito = codDeposito;
        }
        public ProdutoVD(int? codProduto, string nomeProduto, double? precoCustoMedio, string caminhoImagemPrincipal, int qtdDisponivel, FornecedorVD fornecedor, CategoriaVD categoria, bool indProdutoEmDestaque, int codDeposito)
        {
            CodProduto = codProduto;
            NomeProduto = nomeProduto;
            PrecoCustoMedio = precoCustoMedio;
            CaminhoImagemPrincipal = caminhoImagemPrincipal;
            QtdDisponivel = qtdDisponivel;
            Fornecedor = fornecedor;
            Categoria = categoria;
            IndProdutoEmDestaque = indProdutoEmDestaque;
            CodDeposito = codDeposito;
        }
    }
}
