﻿using Ecommerce.Models.Resultado;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Login
{
    public interface ILoginService
    {
        public UsuarioVD RealizarLogin(LoginVD login);
    }
}
