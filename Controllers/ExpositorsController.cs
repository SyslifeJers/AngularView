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
    public class ExpositorsController : Controller
    {
        private readonly AngularViewContext _context;

        public ExpositorsController(AngularViewContext context)
        {
            _context = context;
        }

        // GET: Expositors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expositor.ToListAsync());
        }

        // GET: Expositors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expositor = await _context.Expositor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expositor == null)
            {
                return NotFound();
            }

            return View(expositor);
        }

        // GET: Expositors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expositors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Correo,Password,Token,Registro,Nombre,Apellidos,Activo,Modificado,Celular,Negocio")] Expositor expositor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expositor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expositor);
        }

        // GET: Expositors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expositor = await _context.Expositor.FindAsync(id);
            if (expositor == null)
            {
                return NotFound();
            }
            return View(expositor);
        }

        // POST: Expositors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Correo,Password,Token,Registro,Nombre,Apellidos,Activo,Modificado,Celular,Negocio")] Expositor expositor)
        {
            if (id != expositor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expositor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpositorExists(expositor.Id))
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
            return View(expositor);
        }

        // GET: Expositors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expositor = await _context.Expositor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expositor == null)
            {
                return NotFound();
            }

            return View(expositor);
        }

        // POST: Expositors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expositor = await _context.Expositor.FindAsync(id);
            _context.Expositor.Remove(expositor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpositorExists(int id)
        {
            return _context.Expositor.Any(e => e.Id == id);
        }
    }
}
