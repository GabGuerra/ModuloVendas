using Ecommerce.Models.Categoria;
using Ecommerce.Models.Fornecedor;
using Ecommerce.Models.Produto;
using Ecommerce.Repositories.Shared;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Produto
{
    public class ProdutoRepository :  DbRepository<ProdutoVD>, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration config) : base(config) { }
        public List<ProdutoVD> ListarProdutos()
        {
            string sql = @"SELECT
	                           P.COD_PRODUTO,
                               P.NOME_PRODUTO,
                               P.PRECO_CUSTO_MEDIO,
                               NVL(FUNC_QTD_DISPONIVEL(P.COD_PRODUTO, D.COD_DEPOSITO),0) AS QTD_DISPONIVEL,                               
                               P.CAMINHO_IMG_PRINCIPAL,
                               F.COD_FORNECEDOR,
                               F.NOME_FORNECEDOR,
                               C.COD_CATEGORIA,
                               C.NOME_CATEGORIA                              
                           FROM
	                           PRODUTO P
                           INNER JOIN CATEGORIA C ON P.COD_CATEGORIA = C.COD_CATEGORIA
                           INNER JOIN FORNECEDOR F ON P.COD_FORNECEDOR = F.COD_FORNECEDOR
                           INNER JOIN PRODUTO_DEPOSITO PD ON P.COD_PRODUTO = PD.COD_PRODUTO
                           INNER JOIN DEPOSITO D ON PD.COD_DEPOSITO = D.COD_DEPOSITO;";

            List<ProdutoVD> listaProdutos = new List<ProdutoVD>();

            using (var cmd = new MySqlCommand(sql))
            {
                listaProdutos = ObterRegistros(cmd).ToList();
            }

            return listaProdutos;
        }

        public override ProdutoVD PopularDados(MySqlDataReader dr)
        {
            return new ProdutoVD
                (
                    Convert.ToInt32(dr["COD_PRODUTO"]),
                    dr["NOME_PRODUTO"].ToString(),
                    Convert.ToDouble(dr["PRECO_CUSTO_MEDIO"]),
                    dr["CAMINHO_IMG_PRINCIPAL"].ToString(),
                    new FornecedorVD(Convert.ToInt32(dr["COD_FORNECEDOR"]), dr["NOME_FORNECEDOR"].ToString()),
                    new CategoriaVD(Convert.ToInt32(dr["COD_CATEGORIA"]), dr["NOME_CATEGORIA"].ToString())
                );
        }
    }
}
