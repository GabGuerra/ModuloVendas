﻿using Ecommerce.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Produto
{
    public interface IProdutoService
    {
        public List<ProdutoVD> ListarProdutos();
        public List<ProdutoVD> ListarProdutosRecomendados();
        public ProdutoVD CarregarDetalheProduto(int codProduto);
    }
}
