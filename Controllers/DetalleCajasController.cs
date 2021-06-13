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
    public class DetalleCajasController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public DetalleCajasController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: DetalleCajas
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.DetalleCaja.Include(d => d.IdCajaNavigation).Include(d => d.IdExpositorNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: DetalleCajas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCaja = await _context.DetalleCaja
                .Include(d => d.IdCajaNavigation)
                .Include(d => d.IdExpositorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleCaja == null)
            {
                return NotFound();
            }

            return View(detalleCaja);
        }

        // GET: DetalleCajas/Create
        public IActionResult Create()
        {
            ViewData["IdCaja"] = new SelectList(_context.Caja, "Id", "Id");
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id");
            return View();
        }

        // POST: DetalleCajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdExpositor,Titulo,Resumen,RedWhats,RedFacebook,RedInstagram,VideoYoutube,IdCaja,Modificado")] DetalleCaja detalleCaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCaja"] = new SelectList(_context.Caja, "Id", "Id", detalleCaja.IdCaja);
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", detalleCaja.IdExpositor);
            return View(detalleCaja);
        }

        // GET: DetalleCajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCaja = await _context.DetalleCaja.FindAsync(id);
            if (detalleCaja == null)
            {
                return NotFound();
            }
            ViewData["IdCaja"] = new SelectList(_context.Caja, "Id", "Id", detalleCaja.IdCaja);
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", detalleCaja.IdExpositor);
            return View(detalleCaja);
        }

        // POST: DetalleCajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdExpositor,Titulo,Resumen,RedWhats,RedFacebook,RedInstagram,VideoYoutube,IdCaja,Modificado")] DetalleCaja detalleCaja)
        {
            if (id != detalleCaja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCajaExists(detalleCaja.Id))
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
            ViewData["IdCaja"] = new SelectList(_context.Caja, "Id", "Id", detalleCaja.IdCaja);
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", detalleCaja.IdExpositor);
            return View(detalleCaja);
        }

        // GET: DetalleCajas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCaja = await _context.DetalleCaja
                .Include(d => d.IdCajaNavigation)
                .Include(d => d.IdExpositorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleCaja == null)
            {
                return NotFound();
            }

            return View(detalleCaja);
        }

        // POST: DetalleCajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleCaja = await _context.DetalleCaja.FindAsync(id);
            _context.DetalleCaja.Remove(detalleCaja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCajaExists(int id)
        {
            return _context.DetalleCaja.Any(e => e.Id == id);
        }
    }
}
