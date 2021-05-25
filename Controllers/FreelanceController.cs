using AngularView.Models;
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
        private readonly AngularViewContext _context;
        
        public FreelanceController(AngularViewContext context)
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
        [HttpPost]
        public JsonResult Alta(Repuesta repuesta)
        {

            try
            {
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                string token = Convert.ToBase64String(time.Concat(key).ToArray());
                repuesta.Token = token;
                List<Vendedores> vendedores = _context.Vendedores.Where(d => d.IdFreelance == repuesta.id).ToList();
                if (vendedores.Count > 0)
                {

                    HttpContext.Session.SetString("id", repuesta.id);
                    HttpContext.Session.SetString("nombre", repuesta.nombre);
                    repuesta.repuesta = true;
                    _context.Update(vendedores[0]);
                    _context.SaveChanges();
                }
                else
                {
                    Vendedores agregar = new Vendedores() { IdFreelance = repuesta.id, Nombre = repuesta.nombre, Token = token };
                    _context.Vendedores.Add(agregar);
                    _context.SaveChanges();

                    repuesta.repuesta = true;
                }
            }
            catch (Exception)
            {

                repuesta.repuesta = false;
            }

            return Json(repuesta);
        }
    }
}
