using Ecommerce.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Movimentacao
{
    public class MovimentacaoDetalhe
    {
        public ProdutoMovimentacao Produto { get; set; }        
        public int QtdMovimentacao { get; set; }
        public double PrecoUnitarioMovimentacao { get; set; }
        public Deposito Deposito { get; set; }
        public MovimentacaoDetalhe()
        {
            Produto = new ProdutoMovimentacao();
            Deposito = new Deposito();
        }

        public MovimentacaoDetalhe(ProdutoMovimentacao produto, int qtdMovimentacao, Deposito deposito)
        {
            Produto = produto;            
            QtdMovimentacao = qtdMovimentacao;
            Deposito = deposito;
        }
    }
}
