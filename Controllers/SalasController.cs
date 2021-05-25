using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularView.Models;
using Microsoft.AspNetCore.Http;
using AngularView.Models.ViewModels;
using AutoMapper;

namespace AngularView.Controllers
{
    public class SalasController : Controller
    {
        private readonly AngularViewContext _context;
        private readonly IMapper _mapper;
        public SalasController(AngularViewContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }

            return View(await _context.Evento.Include(d=>d.Caja).ToListAsync());
        }
        public async Task<IActionResult> TomarCajon(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            var Cajon = await _context.Caja.FindAsync(id);
            ProcesoVentaModel model = new ProcesoVentaModel();
            model.Id_Cajon = Cajon.Id;
            model.NombreCajon = Cajon.Descripcion;
            model.Costo = Cajon.Costo;
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TomarCajon(ProcesoVentaModel model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            var klist =  _context.Expositor.Where(r => r.Correo.Equals(model.Correo)).ToList();
            if (klist.Count()!=0)
            {
                model.Respuesta = "El correo ya esta registrado";
                return View(model);
            }
            int id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (ModelState.IsValid)
            {

                var coaka = _context.Caja.Find(model.Id_Cajon);
                coaka.Ocupado = 1;
                _context.Update(coaka);

                Expositor expositor = new Expositor();
                expositor = _mapper.Map<Expositor>(model);
                expositor.Activo = false;
                expositor.Modificado = DateTime.Now;
                expositor.Registro = DateTime.Now;
                _context.Expositor.Add(expositor);
                _context.SaveChanges();

                AltaExpositor altaExpositor = new AltaExpositor();
                altaExpositor.Activo = true;
                altaExpositor.IdExpositor = expositor.Id;
                altaExpositor.Fecha = DateTime.Now;
                altaExpositor.Modificado = DateTime.Now;
                altaExpositor.IdVendedor = id;

                VentaEspacio ventaEspacio = new VentaEspacio();
                ventaEspacio.Fecha = DateTime.Now;
                ventaEspacio.IdCajon = model.Id_Cajon;
                ventaEspacio.IdVendedor = id;
                ventaEspacio.IdExpositor = expositor.Id;
                ventaEspacio.Total = Convert.ToDecimal(model.Costo);
                ventaEspacio.Estatus = 1;
                _context.VentaEspacio.Add(ventaEspacio);
                _context.AltaExpositor.Add(altaExpositor);
                _context.SaveChanges();
                return View("DetallesAlta", _context.VentaEspacio.Include(
                    d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Where(l => l.IdVendedor == id).ToList().OrderBy(f => f.Fecha));
            }


            return View(model);
        }
        public async Task<IActionResult> DetallesAlta()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            int id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            return View(_context.VentaEspacio.Include(d=>d.IdExpositorNavigation).Include(d=>d.IdCajonNavigation).Where(l=>l.IdVendedor == id).ToList().OrderBy(f=>f.Fecha));
        }
        public async Task<IActionResult> Salas(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            return View(await _context.Sala.Include(d=>d.Caja).Where(f=>f.IdEvento==id).ToListAsync());
        }
        public async Task<IActionResult> Cajas(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            return View(await _context.Caja.Where(f=>f.IdSala==id).OrderBy(d=>d.Descripcion).ToListAsync());
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroSala,Nombre,TipoSala,Activo,Modificado,Espacios")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sala.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroSala,Nombre,TipoSala,Activo,Modificado,Espacios")] Sala sala)
        {
            if (id != sala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sala = await _context.Sala.FindAsync(id);
            _context.Sala.Remove(sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
            return _context.Sala.Any(e => e.Id == id);
        }
    }
}
