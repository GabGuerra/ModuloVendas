using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Fornecedor
{
    public class FornecedorVD
    {
        public int CodFornecedor { get; set; }
        public string DscFornecedor { get; set; }
        public FornecedorVD()
        {

        }
        public FornecedorVD(int codFornecedor, string dscFornecedor)
        {
            CodFornecedor = codFornecedor;
            DscFornecedor = dscFornecedor;
        }
    }
}
