using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Shared
{
    public abstract class DbRepository
    {
        private static MySqlConnection _conn;

        public DbRepository(IConfiguration config)
        {
            _conn = new MySqlConnection(config.GetConnectionString("ConexaoPadrao"));
        }

        protected void ExecutarComando(MySqlCommand cmd)
        {
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.Text;
            _conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
