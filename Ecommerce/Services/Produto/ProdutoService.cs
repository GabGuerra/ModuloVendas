using Ecommerce.Models.Produto;
using Ecommerce.Repositories.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public List<ProdutoVD> ListarProdutos() 
        {
            return _produtoRepository.ListarProdutos();
        }

        public ProdutoVD CarregarDetalheProduto(int codProduto)
        {
            ProdutoVD produto = _produtoRepository.CarregarDetalheProduto(codProduto);
            produto.ListaImagens = _produtoRepository.ListarImagensProduto(codProduto);
            return produto;
        }
    }
}
