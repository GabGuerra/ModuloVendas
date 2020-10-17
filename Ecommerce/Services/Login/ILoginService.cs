using Ecommerce.Models.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Login
{
    public interface ILoginService
    {
        public ResultadoVD RealizarLogin(string email, string senha);
    }
}
