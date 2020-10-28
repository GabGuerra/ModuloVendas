using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Categoria
{
    public class CategoriaVD
    {
        public int CodCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public CategoriaVD(int codCategoria, string nomeCategoria)
        {
            CodCategoria = codCategoria;
            NomeCategoria = nomeCategoria;
        }
        public CategoriaVD()
        {

        }
    }
}
