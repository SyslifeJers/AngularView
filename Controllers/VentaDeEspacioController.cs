using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Controllers
{
    public class VentaDeEspacioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
