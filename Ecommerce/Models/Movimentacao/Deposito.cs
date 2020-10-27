using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Movimentacao
{
    public class Deposito
    {
        public int CodDeposito { get; set; }
        public Deposito(int codDeposito)
        {
            CodDeposito = codDeposito;
        }
        public Deposito()
        {

        }
    }
}
