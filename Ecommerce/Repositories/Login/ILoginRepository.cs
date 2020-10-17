using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Login
{
    public interface ILoginRepository
    {
        public IDataReader RealizarLogin(string email, string senha);
    }
}
