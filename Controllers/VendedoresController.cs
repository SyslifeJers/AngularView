using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularView.Models;
using AngularView.Models.ViewModels;
using AutoMapper;

namespace AngularView.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly AngularViewContext _context;
        private readonly IMapper _mapper;
        public VendedoresController(AngularViewContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Vendedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendedores.ToListAsync());
        }

        // GET: Vendedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedores = await _context.Vendedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return View(vendedores);
        }

        // GET: Vendedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoginFreeModel vendedores)
        {
            if (ModelState.IsValid)
            {
                List<Vendedores> listVender = await _context.Vendedores.Where(f => f.Correo.Equals(vendedores.Correo)).ToListAsync();
                if (listVender.Count ==0)
                {
                    Vendedores vended = _mapper.Map<Vendedores>(vendedores);
                    vended.Activo = false;
                    vended.Comision = 0;
                    vended.FechaCaducidad = DateTime.Now;
                    vended.Modificado = DateTime.Now;

                    _context.Add(vended);
                    await _context.SaveChangesAsync();
                    return Redirect(Url.ActionLink("Index", "Home")); 
                }
            }
            return View(vendedores);
        }

        // GET: Vendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedores = await _context.Vendedores.FindAsync(id);
            if (vendedores == null)
            {
                return NotFound();
            }
            return View(vendedores);
        }

        // POST: Vendedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFreelance,Nombre,Token,Correo,Passworsd,Activo,Modificado,FechaCaducidad,Comision")] Vendedores vendedores)
        {
            if (id != vendedores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedoresExists(vendedores.Id))
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
            return View(vendedores);
        }

        // GET: Vendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedores = await _context.Vendedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return View(vendedores);
        }

        // POST: Vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedores = await _context.Vendedores.FindAsync(id);
            _context.Vendedores.Remove(vendedores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedoresExists(int id)
        {
            return _context.Vendedores.Any(e => e.Id == id);
        }
    }
}
