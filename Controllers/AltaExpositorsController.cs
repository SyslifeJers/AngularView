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
    public class AltaExpositorsController : Controller
    {
        private readonly AngularViewContext _context;

        public AltaExpositorsController(AngularViewContext context)
        {
            _context = context;
        }

        // GET: AltaExpositors
        public async Task<IActionResult> Index()
        {

            var angularViewContext = _context.AltaExpositor.Include(a => a.IdExpositorNavigation).Include(a => a.IdVendedorNavigation);
            return View(await angularViewContext.ToListAsync());
        }

        // GET: AltaExpositors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altaExpositor = await _context.AltaExpositor
                .Include(a => a.IdExpositorNavigation)
                .Include(a => a.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (altaExpositor == null)
            {
                return NotFound();
            }

            return View(altaExpositor);
        }

        // GET: AltaExpositors/Create
        public IActionResult Create()
        {
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id");
            return View();
        }

        // POST: AltaExpositors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdVendedor,IdExpositor,Fecha,Activo,Modificado")] AltaExpositor altaExpositor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(altaExpositor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", altaExpositor.IdExpositor);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", altaExpositor.IdVendedor);
            return View(altaExpositor);
        }

        // GET: AltaExpositors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altaExpositor = await _context.AltaExpositor.FindAsync(id);
            if (altaExpositor == null)
            {
                return NotFound();
            }
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", altaExpositor.IdExpositor);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", altaExpositor.IdVendedor);
            return View(altaExpositor);
        }

        // POST: AltaExpositors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdVendedor,IdExpositor,Fecha,Activo,Modificado")] AltaExpositor altaExpositor)
        {
            if (id != altaExpositor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(altaExpositor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AltaExpositorExists(altaExpositor.Id))
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
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", altaExpositor.IdExpositor);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", altaExpositor.IdVendedor);
            return View(altaExpositor);
        }

        // GET: AltaExpositors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altaExpositor = await _context.AltaExpositor
                .Include(a => a.IdExpositorNavigation)
                .Include(a => a.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (altaExpositor == null)
            {
                return NotFound();
            }

            return View(altaExpositor);
        }

        // POST: AltaExpositors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var altaExpositor = await _context.AltaExpositor.FindAsync(id);
            _context.AltaExpositor.Remove(altaExpositor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AltaExpositorExists(int id)
        {
            return _context.AltaExpositor.Any(e => e.Id == id);
        }
    }
}
