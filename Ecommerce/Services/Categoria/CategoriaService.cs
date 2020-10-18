using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Categoria;
using Ecommerce.Repositories.Categoria;

namespace Ecommerce.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public List<CategoriaVD> ListarCategorias()
        {
            return _categoriaRepository.ListarCategorias();
        }
    }
}
