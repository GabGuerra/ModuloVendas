using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult CadastroUsuarioIndex()
        {
            return View();
        }
    }
}