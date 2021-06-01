using AngularView.Models;
using AngularView.Models.Context;
using AngularView.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Controllers
{
    public class FreelanceController : Controller
    {
        private readonly u535755128_AngularviewContext _context;
        
        public FreelanceController(u535755128_AngularviewContext context)
        {
            _context = context;
        }
        public IActionResult TomarCaja(int? id)
        {
            RegistroCajonVendedor registro = new RegistroCajonVendedor();
            registro.GetCaja = _context.Caja.Find(id);
            return View(registro);
        }
        public IActionResult Salas()
        {
          ///  string name = HttpContext.Session.GetString("Name");
            SalasView salasView = new SalasView();
            salasView.salas = _context.Sala.Include(s=>s.Caja).ToList();
            salasView.SalaUno = salasView.salas[0].Caja.Count().ToString();
            salasView.SalaDos = salasView.salas[1].Caja.Count().ToString();
            salasView.SalaTres = salasView.salas[2].Caja.Count().ToString();
            return View(salasView);
        }

        public IActionResult CajonesDiponibles(int? id)
        {
            List<Caja> liscaja = new List<Caja>();
            liscaja = _context.Caja.Include(d => d.IdEventoNavigation).Include(d => d.IdSalaNavigation).Where(f => f.IdSala == id).ToList();

            return View(liscaja);
        }


        public IActionResult Index()
        {                 
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            int id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            return View(_context.Vendedores.Find(id));
        }

        public IActionResult Alta(string id, string nombre)
        {

            try
            {
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                string token = Convert.ToBase64String(time.Concat(key).ToArray());
                //repuesta.Token = token;
                List<Vendedores> vendedores = _context.Vendedores.Where(d => d.IdFreelance == id).ToList();
                if (vendedores.Count > 0)
                {

                    HttpContext.Session.SetString("id", vendedores[0].Id.ToString());
                    HttpContext.Session.SetString("nombre", vendedores[0].Nombre);
                  //  repuesta.repuesta = true;
                    _context.Update(vendedores[0]);
                    _context.SaveChanges();

                    return Redirect(Url.ActionLink("Index", "Freelance"));
                }
                else
                {
                    Vendedores agregar = new Vendedores() { IdFreelance = id, Nombre = nombre, Token = token, Comision = 0,Activo = 1,FechaCaducidad = DateTime.Now.AddDays(5),Modificado = DateTime.Now, };
                    _context.Vendedores.Add(agregar);
                    _context.SaveChanges();

                    HttpContext.Session.SetString("id", agregar.Id.ToString());
                    HttpContext.Session.SetString("nombre", agregar.Nombre);
                    return Redirect(Url.ActionLink("Index", "Freelance"));
                    //repuesta = true;
                }
            }
            catch (Exception)
            {

                //repuesta = false;
            }

            return View();
        }
        public async Task<IActionResult> AltaVenta(string id, string nombre,string CorreoExpo,string EmpresaExpo,string nombreExpo, string CelularExpo)
        {

            try
            {
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                string token = Convert.ToBase64String(time.Concat(key).ToArray());
                //repuesta.Token = token;
                List<Vendedores> vendedores = _context.Vendedores.Where(d => d.IdFreelance == id).ToList();
                if (vendedores.Count > 0)
                {

                    HttpContext.Session.SetString("id", vendedores[0].Id.ToString());
                    HttpContext.Session.SetString("nombre", vendedores[0].Nombre);
                    //  repuesta.repuesta = true;
                    _context.Update(vendedores[0]);
                    _context.SaveChanges();


                }
                else
                {
                    Vendedores agregar = new Vendedores() { IdFreelance = id, Nombre = nombre, Token = token, Comision = 0, Activo = 1, FechaCaducidad = DateTime.Now.AddDays(5), Modificado = DateTime.Now, };
                    _context.Vendedores.Add(agregar);
                    _context.SaveChanges();

                    HttpContext.Session.SetString("id", agregar.Id.ToString());
                    HttpContext.Session.SetString("nombre", agregar.Nombre);
                }
            }
            catch (Exception)
            {

                //repuesta = false;
            }
            var altaexpo = await _context.Expositor.Where(f => f.Correo.Equals(CorreoExpo)).ToListAsync();
            if (altaexpo.Count==0)
            {
                AltaExpoFreelance altaExpoFreelance = new AltaExpoFreelance()
                {
                    Correo = CorreoExpo,
                    Negocio = EmpresaExpo,
                    Celular = CelularExpo,
                    Nombre = nombreExpo,
                    Registrado = false
                };
                Expositor expositor = new Expositor()
                {
                    Activo = 1,
                    Modificado = DateTime.Now,
                    Celular = CelularExpo,
                    Correo = CorreoExpo,
                    Negocio = EmpresaExpo,
                    Nombre = nombreExpo,
                    Registro = DateTime.Now,
                   
                 
                };
                _context.Expositor.Add(expositor);
                await _context.SaveChangesAsync();
                altaExpoFreelance.Id = expositor.Id;
                altaExpoFreelance.Registrado = true;
                altaExpoFreelance.vendedores = expositor;
                return View(altaExpoFreelance);
            }
            else
            {
                AltaExpoFreelance altaExpoFreelance = new AltaExpoFreelance()
                {
                    Id = altaexpo[0].Id,
                    vendedores = altaexpo[0],
                    Registrado = true
                };
                return View(altaExpoFreelance);
            }


        }

    }
}
