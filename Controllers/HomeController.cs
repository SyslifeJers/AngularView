using AngularView.Models;
using AngularView.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AngularViewContext _context;
        public HomeController(ILogger<HomeController> logger,AngularViewContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Freelance"));
            }
            return View();
        }

        public IActionResult Expo()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Freelance"));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
           if(ModelState.IsValid)
                {
                var logi = await _context.Vendedores.Where(d => d.Correo.Equals(loginModel.Correo)&&d.Activo==true).ToListAsync();
                if (logi.Count == 1)
                {
                    if (logi[0].Passworsd.Equals(loginModel.Passworsd))
                    {

                        HttpContext.Session.SetString("id", logi[0].Id.ToString());
                        HttpContext.Session.SetString("nombre", logi[0].Nombre);
                        return Redirect(Url.ActionLink("Index","Freelance"));
                    }
                    else
                    {
                        loginModel.Respuesta = "Este correo o contraseña es erronea";
                    }
                }
                else
                    loginModel.Respuesta = "Este correo es no existe o esta en espera de activacion";
            }
            return View(loginModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
