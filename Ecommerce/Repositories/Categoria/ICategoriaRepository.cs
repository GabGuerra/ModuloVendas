using Ecommerce.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Categoria
{
    public interface ICategoriaRepository
    {
        public List<CategoriaVD> ListarCategorias();
    }
}
