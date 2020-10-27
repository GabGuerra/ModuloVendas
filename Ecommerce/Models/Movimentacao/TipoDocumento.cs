using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Movimentacao
{
    public class TipoDocumento
    {
        public int CodTipoDocumento { get; set; }
        public string DscTipoDocumento { get; set; }
        public TipoDocumento()
        {

        }
        public TipoDocumento(int codTipoDocumento, string dscTipoDocumento)
        {
            CodTipoDocumento = codTipoDocumento;
            DscTipoDocumento = dscTipoDocumento;
        }
        public TipoDocumento(string dscTipoDocumento)
        {
            DscTipoDocumento = dscTipoDocumento;
        }
    }
}
