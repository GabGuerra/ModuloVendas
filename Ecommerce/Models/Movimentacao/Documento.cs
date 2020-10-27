using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Movimentacao
{
    public class Documento
    {
        public int? CodMovimentacao { get; set; }
        public DateTime? DatMovimentacao { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public UsuarioVD Cliente { get; set; }
        public List<MovimentacaoDetalhe> ListaMovimentacaoDetalhe { get; set; }
        public Documento()
        {
            Cliente = new UsuarioVD();
            ListaMovimentacaoDetalhe = new List<MovimentacaoDetalhe>();
            TipoDocumento = new TipoDocumento();
        }
    }
}
