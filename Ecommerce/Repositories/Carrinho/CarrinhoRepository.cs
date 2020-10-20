using Ecommerce.Models.Carrinho;
using Ecommerce.Models.Produto;
using Ecommerce.Repositories.Shared;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Carrinho
{
    public class CarrinhoRepository : DbRepository<CarrinhoVD>, ICarrinhoRepository
    {
        public CarrinhoRepository(IConfiguration config) : base(config) { }

        public void AdicionarItem(CarrinhoItemVD item, int codCarrinho)
        {
            string sql = @"INSERT INTO CARRINHO_ITEM (QTD_ITEM, COD_PRODUTO, COD_CARRINHO) VALUES (@QTD_ITEM, @COD_PRODUTO, @COD_CARRINHO)";

            using (var cmd = new MySqlCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@QTD_ITEM", item.QtdProduto);
                    cmd.Parameters.AddWithValue("@COD_PRODUTO", item.Produto.CodProduto);
                    cmd.Parameters.AddWithValue("@COD_CARRINHO", codCarrinho);

                    ExecutarComando(cmd);
                }
                catch
                {
                    throw;
                }
            }
        }

        public CarrinhoVD CarregarDetalheCarrinho(int codCarrinho)
        {
            CarrinhoVD carrinho = new CarrinhoVD(codCarrinho);
            string sql = @"SELECT
	                           CPF_USUARIO,
                               CI.QTD_ITEM,
                               P.COD_PRODUTO,
                               P.NOME_PRODUTO,
                               P.DSC_PRODUTO,
                               P.PRECO_CUSTO_MEDIO,
                                (SELECT 
                                        CAMINHO_IMAGEM 
                                 FROM PRODUTO_IMAGEM PI 
                                 WHERE
                                      PI.COD_PRODUTO = P.COD_PRODUTO
                                 AND  PI.IND_PRINCIPAL = 1 
                                ) AS CAMINHO_IMAGEM
                           FROM
	                           CARRINHO C
                           INNER JOIN CARRINHO_ITEM CI ON C.COD_CARRINHO = CI.COD_CARRINHO
                           INNER JOIN PRODUTO P ON CI.COD_PRODUTO = P.COD_PRODUTO
                           WHERE
	                           C.COD_CARRINHO = @COD_CARRINHO";
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                _conn.Open();
                cmd.Parameters.AddWithValue("@COD_CARRINHO", codCarrinho);                
                using (var dr = cmd.ExecuteReader())
                {
                    try
                    {
                        while (dr.Read())
                        {
                            ProdutoVD produto = new ProdutoVD(Convert.ToInt32(dr["COD_PRODUTO"]), dr["NOME_PRODUTO"].ToString(), Convert.ToDouble(dr["PRECO_CUSTO_MEDIO"]), dr["CAMINHO_IMAGEM"].ToString());
                            carrinho.ListaItens.Add(new CarrinhoItemVD(produto, Convert.ToInt32(dr["QTD_ITEM"])));
                        }
                    }
                    finally
                    {
                        dr.Close();
                    }
                }
            }
            return carrinho;
        }

        public int CriarCarrinho(string cpfUsuario)
        {
            string sql = @"INSERT INTO CARRINHO(CPF_USUARIO) VALUES (@CPF_USUARIO);
                           SELECT LAST_INSERT_ID();";

            using (var cmd = new MySqlCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@CPF_USUARIO", cpfUsuario);

                    return ExecutarComando(cmd);
                }
                catch
                {
                    throw;
                }
            }
        }

        public void RemoverItem(CarrinhoItemVD item, int codCarrinho)
        {
            string sql = @"DELETE FROM 
                                CARRINHO_ITEM 
                           WHERE
                                COD_PRODUTO = @COD_PRODUTO 
                           AND  COD_CARRINHO = @COD_CARRINHO";

            using (var cmd = new MySqlCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@COD_PRODUTO", item.Produto.CodProduto);
                    cmd.Parameters.AddWithValue("@COD_CARRINHO", codCarrinho);
                    ExecutarComando(cmd);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
