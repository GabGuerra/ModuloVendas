using Ecommerce.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Categoria
{
    public interface ICategoriaService
    {
        public List<CategoriaVD> ListarCategorias();
    }
}
