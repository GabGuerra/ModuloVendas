using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Categoria;
using Ecommerce.Repositories.Shared;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Ecommerce.Repositories.Categoria
{
    public class CategoriaRepository : DbRepository<CategoriaVD>, ICategoriaRepository
    {
        public CategoriaRepository(IConfiguration config) : base(config) { }
        public List<CategoriaVD> ListarCategorias()
        {
            string sql = @"SELECT * FROM CATEGORIA;";
            List<CategoriaVD> listaCategorias = new List<CategoriaVD>();
            using (var cmd = new MySqlCommand(sql))
            {
                listaCategorias = ObterRegistros(cmd).ToList();
            }
            return listaCategorias;
        }

        public override CategoriaVD PopularDados(MySqlDataReader dr)
        {
            return new CategoriaVD
                (
                    Convert.ToInt32(dr["COD_CATEGORIA"]),
                    dr["NOME_CATEGORIA"].ToString()
                );
        }
    }
}
