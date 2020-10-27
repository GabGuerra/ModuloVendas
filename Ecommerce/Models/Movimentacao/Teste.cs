using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Movimentacao
{
    public class Teste
    {
        public int CodProduto { get; set; }
        public int QtdAdicionar { get; set; }
        public string CpfUsuario { get; set; }
        public int CodDeposito { get; set; }

      
        public Teste(int codProduto, int qtdAdicionar, string cpfUsuario, int codDeposito)
        {
            CodProduto = codProduto;
            QtdAdicionar = qtdAdicionar;
            CpfUsuario = cpfUsuario;
            CodDeposito = codDeposito;
        }
     
        public Teste()
        {

        }
    }

}
