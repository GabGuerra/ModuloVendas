﻿using Ecommerce.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Produto
{
    public interface IProdutoRepository
    {
        public List<ProdutoVD> ListarProdutos();
    }
}
