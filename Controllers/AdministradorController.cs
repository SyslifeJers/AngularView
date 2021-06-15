
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
    public class AdministradorController : Controller
    {
        private readonly u535755128_AngularviewContext _context;
        public AdministradorController(u535755128_AngularviewContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> DeleteEspaci(int id)
        {
            VentaEspacio ventaEspacio = await _context.VentaEspacio.FindAsync(id);
            Caja caja = await _context.Caja.FindAsync(ventaEspacio.IdCajon);
            caja.Ocupado = 0;
            _context.Update(caja);
            ventaEspacio.Estatus = -1;
            _context.Update(ventaEspacio);
            await _context.SaveChangesAsync();

            ModelListadoVentas model = new ModelListadoVentas();
            model.Vendedores = await _context.Vendedores.ToListAsync();
            model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == 1).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
            return View("Index",model);
        }
        public async Task<IActionResult> ConfirmEspacio(int id)
        {
            VentaEspacio ventaEspacio = await _context.VentaEspacio.Include(i => i.IdExpositorNavigation)
    .FirstOrDefaultAsync(i => i.Id == id); ;
            Caja caja = await _context.Caja.FindAsync(ventaEspacio.IdCajon);
            Vendedores vend = await _context.Vendedores.FindAsync(ventaEspacio.IdVendedor);
            vend.Comision += 300;
            vend.FechaCaducidad = DateTime.Now.AddDays(5);
            _context.Update(vend);
            caja.Ocupado = 2;
            _context.Update(caja);
            ventaEspacio.Estatus = 2;
            _context.Update(ventaEspacio);
            await _context.SaveChangesAsync();

            Herramientas.Correo(ventaEspacio.IdExpositorNavigation.Correo, "Pago a sido confirmado", "<h3>Tu pago fue confirmado ingrese a <a href='http://angularviewexpo.com/AdminExpositores/Login'>Angular View </a><h3><p>En este paso ingresa con tu correo y tu contraseña temporal es:Tem264 ,dentro se te pedira dar de alta una contraseña para seguir ingresando</p>");

            ModelListadoVentas model = new ModelListadoVentas();
            model.Vendedores = _context.Vendedores.Include(d => d.AltaExpositor).ToList();
            model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == 1).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
            return View("Index", model);
        }
        public async Task<IActionResult> Confirmreenvio(int id)
        {
            VentaEspacio ventaEspacio = await _context.VentaEspacio.Include(i => i.IdExpositorNavigation)
    .FirstOrDefaultAsync(i => i.Id == id); ;
          

            Herramientas.Correo(ventaEspacio.IdExpositorNavigation.Correo, "Pago a sido confirmado", "<h3>Tu pago fue confirmado ingrese a <a href='http://angularviewexpo.com/AdminExpositores/Login'>Angular View </a><h3><p>En este paso ingresa con tu correo y tu contraseña temporal es:Tem264 ,dentro se te pedira dar de alta una contraseña para seguir ingresando</p>");

            ModelListadoVentas model = new ModelListadoVentas();
            model.Vendedores = _context.Vendedores.Include(d => d.AltaExpositor).ToList();
            model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == 1).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
            return View("Index", model);
        }

        // GET: AdministradorController1
        public ActionResult Index()
        {
            ModelListadoVentas model = new ModelListadoVentas();
            model.Vendedores = _context.Vendedores.Include(d=>d.AltaExpositor).ToList();
            model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == 1).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
            return View(model);
        }
        public ActionResult ListaVentas()
        {
            ModelListadoVentas model = new ModelListadoVentas();

            model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == 2).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
            return View(model);
        }
        public ActionResult ListaVentasCanceladas()
        {
            ModelListadoVentas model = new ModelListadoVentas();

            model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == -1).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
            return View(model);
        }

        // GET: AdministradorController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministradorController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministradorController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdministradorController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministradorController1/Edit/5

        public async Task<IActionResult> Activar(int id)
        {

            try
            {
                Vendedores vendedores = await _context.Vendedores.FindAsync(id);
                if (vendedores.Activo==1)
                {
                    vendedores.Activo = 0;
                }
                else
                {
                    vendedores.Activo = 1;
                    vendedores.FechaCaducidad = DateTime.Now.AddDays(15);
                }
                _context.Update(vendedores);
                await _context.SaveChangesAsync();
                ModelListadoVentas model = new ModelListadoVentas();
                model.Vendedores = _context.Vendedores.Include(d => d.AltaExpositor).ToList();
                model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == 1).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
                return View("Index", model);
            }
            catch
            {
                ModelListadoVentas model = new ModelListadoVentas();
                model.Vendedores = _context.Vendedores.Include(d => d.AltaExpositor).ToList();
                model.ventaEspacios = _context.VentaEspacio.Where(d => d.Estatus == 1).Include(d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Include(d => d.IdVendedorNavigation).Include(d => d.IdCajonNavigation.IdSalaNavigation).ToList();
                return View("Index", model);
            }
        }

        // GET: AdministradorController1/Delete/5
        public async Task<IActionResult> Detalle(int id)
        {
            var vendedores = await _context.Vendedores.Include(d=>d.VentaEspacio).Where(f=>f.Id==id).ToListAsync();
            return View(vendedores[0]);
        }


    }
}
