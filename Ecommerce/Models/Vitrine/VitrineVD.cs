using Ecommerce.Models.Categoria;
using Ecommerce.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Vitrine
{
    public class VitrineVD
    {
        public List<ProdutoVD> ListaProdutos { get; set; }
        public List<CategoriaVD> ListaCategorias { get; set; }
        public VitrineVD()
        {
            ListaProdutos = new List<ProdutoVD>();
            ListaCategorias = new List<CategoriaVD>();
        }
        public VitrineVD(List<ProdutoVD> listaProdutos, List<CategoriaVD> listaCategorias)
        {
            ListaProdutos = listaProdutos;
            ListaCategorias = listaCategorias;
        }
    }
}
