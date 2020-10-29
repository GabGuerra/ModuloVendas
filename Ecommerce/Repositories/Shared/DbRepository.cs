using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Shared
{
    public abstract class DbRepository<T> where T : class
    {
        internal static MySqlConnection _conn;

        public DbRepository(IConfiguration config)
        {
            _conn = new MySqlConnection(config.GetConnectionString("ConexaoPadrao"));
        }

        public virtual T PopularDados(MySqlDataReader dr)
        {
            return null;
        }

        protected IEnumerable<T> ObterRegistros(MySqlCommand cmd)
        {
            var lista = new List<T>();
            cmd.Connection = _conn;
            _conn.Open();
            try
            {
                var dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                        lista.Add(PopularDados(dr));
                }
                finally
                {
                    dr.Close();
                }
            }
            finally
            {
                _conn.Close();
            }
            return lista;
        }

        protected T ObterRegistro(MySqlCommand cmd)
        {
            T registro = null;
            cmd.Connection = _conn;
            _conn.Open();
            try
            {
                var dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                        registro = PopularDados(dr);
                }
                finally
                {
                    dr.Close();
                }
            }
            finally
            {
                _conn.Close();
            }
            return registro;
        }

        protected int ExecutarComando(MySqlCommand cmd)
        {
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.Text;
            if(_conn.State != ConnectionState.Open)
            _conn.Open();
            
            try
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
