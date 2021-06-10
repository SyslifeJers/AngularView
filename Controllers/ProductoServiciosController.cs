using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularView.Models;

namespace AngularView.Controllers
{
    public class ProductoServiciosController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public ProductoServiciosController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: ProductoServicios
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.ProductoServicio.Include(p => p.IdExpositorNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: ProductoServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoServicio = await _context.ProductoServicio
                .Include(p => p.IdExpositorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productoServicio == null)
            {
                return NotFound();
            }

            return View(productoServicio);
        }

        // GET: ProductoServicios/Create
        public IActionResult Create()
        {
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id");
            return View();
        }

        // POST: ProductoServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Decripcion,PrecioNormal,PrecioDescuento,Descuento,Tipo,Activo,Modificado,Stock,IdExpositor")] ProductoServicio productoServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", productoServicio.IdExpositor);
            return View(productoServicio);
        }

        // GET: ProductoServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoServicio = await _context.ProductoServicio.FindAsync(id);
            if (productoServicio == null)
            {
                return NotFound();
            }
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", productoServicio.IdExpositor);
            return View(productoServicio);
        }

        // POST: ProductoServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Decripcion,PrecioNormal,PrecioDescuento,Descuento,Tipo,Activo,Modificado,Stock,IdExpositor")] ProductoServicio productoServicio)
        {
            if (id != productoServicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoServicioExists(productoServicio.Id))
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
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", productoServicio.IdExpositor);
            return View(productoServicio);
        }

        // GET: ProductoServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoServicio = await _context.ProductoServicio
                .Include(p => p.IdExpositorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productoServicio == null)
            {
                return NotFound();
            }

            return View(productoServicio);
        }

        // POST: ProductoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoServicio = await _context.ProductoServicio.FindAsync(id);
            _context.ProductoServicio.Remove(productoServicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoServicioExists(int id)
        {
            return _context.ProductoServicio.Any(e => e.Id == id);
        }
    }
}
