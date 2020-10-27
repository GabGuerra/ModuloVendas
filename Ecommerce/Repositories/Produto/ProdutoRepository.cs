using Ecommerce.Models.Categoria;
using Ecommerce.Models.Fornecedor;
using Ecommerce.Models.Produto;
using Ecommerce.Repositories.Shared;
using Ecommerce.Utils;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Produto
{
    public class ProdutoRepository : DbRepository<ProdutoVD>, IProdutoRepository
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
                               C.NOME_CATEGORIA,
                               (SELECT 
									COUNT(1)
								FROM 
									CAMPANHA_FORNECEDOR_PRODUTO CFP 
								WHERE 
									CFP.COD_PRODUTO = P.COD_PRODUTO 
								AND CURDATE() BETWEEN CFP.DAT_INICIO_CAMPANHA AND CFP.DAT_FIM_CAMPANHA) AS IND_DESTAQUE,
                                D.COD_DEPOSITO
                           FROM
	                           PRODUTO P
                           INNER JOIN CATEGORIA C ON P.COD_CATEGORIA = C.COD_CATEGORIA
                           INNER JOIN FORNECEDOR F ON P.COD_FORNECEDOR = F.COD_FORNECEDOR
                           INNER JOIN PRODUTO_DEPOSITO PD ON P.COD_PRODUTO = PD.COD_PRODUTO
                           INNER JOIN DEPOSITO D ON PD.COD_DEPOSITO = D.COD_DEPOSITO
                           ORDER BY IND_DESTAQUE DESC";

            List<ProdutoVD> listaProdutos = new List<ProdutoVD>();

            using (var cmd = new MySqlCommand(sql))
            {
                listaProdutos = ObterRegistros(cmd).ToList();
            }

            return listaProdutos;
        }

        public ProdutoVD CarregarDetalheProduto(int codProduto)
        {
            string sql = @"SELECT
	                           P.COD_PRODUTO,
                               P.NOME_PRODUTO,
                               NVL(P.PRECO_CUSTO_MEDIO,0.0) AS PRECO_CUSTO_MEDIO,
                               NVL(FUNC_QTD_DISPONIVEL(P.COD_PRODUTO, D.COD_DEPOSITO),0) AS QTD_DISPONIVEL,                               
                               P.CAMINHO_IMG_PRINCIPAL,
                               F.COD_FORNECEDOR,
                               F.NOME_FORNECEDOR,
                               C.COD_CATEGORIA,
                               C.NOME_CATEGORIA,                                                        
                               (SELECT 
									COUNT(1)
								FROM 
									CAMPANHA_FORNECEDOR_PRODUTO CFP 
								WHERE 
									CFP.COD_PRODUTO = P.COD_PRODUTO 
								AND CURDATE() BETWEEN CFP.DAT_INICIO_CAMPANHA AND CFP.DAT_FIM_CAMPANHA) AS IND_DESTAQUE,
                                D.COD_DEPOSITO
                           FROM
	                           PRODUTO P
                           INNER JOIN CATEGORIA C ON P.COD_CATEGORIA = C.COD_CATEGORIA
                           INNER JOIN FORNECEDOR F ON P.COD_FORNECEDOR = F.COD_FORNECEDOR
                           INNER JOIN PRODUTO_DEPOSITO PD ON P.COD_PRODUTO = PD.COD_PRODUTO
                           INNER JOIN DEPOSITO D ON PD.COD_DEPOSITO = D.COD_DEPOSITO
                           WHERE
                                P.COD_PRODUTO = @COD_PRODUTO";

            List<ProdutoVD> listaProdutos = new List<ProdutoVD>();

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@COD_PRODUTO", codProduto);

                return ObterRegistro(cmd);
            }
        }

        public override ProdutoVD PopularDados(MySqlDataReader dr)
        {
            return new ProdutoVD
                (
                    dr["COD_PRODUTO"].ToInt(),
                    dr["NOME_PRODUTO"].ToString(),
                    dr["PRECO_CUSTO_MEDIO"].ToDouble(),
                    dr["CAMINHO_IMG_PRINCIPAL"].ToString(),                     
                    dr["QTD_DISPONIVEL"].ToInt(),
                    new FornecedorVD(dr["COD_FORNECEDOR"].ToInt(), dr["NOME_FORNECEDOR"].ToString()),
                    new CategoriaVD(dr["COD_CATEGORIA"].ToInt(), dr["NOME_CATEGORIA"].ToString()),
                    dr["IND_DESTAQUE"].ToBool(),
                    dr["COD_DEPOSITO"].ToInt()
                );
        }

        public List<ImagemProdutoVD> ListarImagensProduto(int codProduto)
        {
            string sql = @"SELECT 
                                COD_IMAGEM,
                                CAMINHO_IMAGEM
                           FROM 
                                PRODUTO_IMAGEM 
                           WHERE 
                                COD_PRODUTO = @COD_PRODUTO";
            List<ImagemProdutoVD> listaImagem = new List<ImagemProdutoVD>();

            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@COD_PRODUTO", codProduto);
                try
                {
                    _conn.Open();                    
                    using (var dr = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (dr.Read())
                                listaImagem.Add(new ImagemProdutoVD(Convert.ToInt32(dr["COD_IMAGEM"]), dr["CAMINHO_IMAGEM"].ToString()));
                        }
                        finally 
                        {
                            dr.Close();
                        }                        
                    }
                }
                catch { throw; }
                finally
                {
                    _conn.Close();
                }
            }

            return listaImagem;
        }
    }
}
