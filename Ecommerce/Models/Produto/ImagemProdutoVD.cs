using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Produto
{
    public class ImagemProdutoVD
    {
        public int CodImagem { get; set; }
        public string CaminhoImagem { get; set; }

        public ImagemProdutoVD() { }
        public ImagemProdutoVD(int codImagem, string caminhoImagem)
        {
            CodImagem = codImagem;
            CaminhoImagem = caminhoImagem;
        }
    }
}
