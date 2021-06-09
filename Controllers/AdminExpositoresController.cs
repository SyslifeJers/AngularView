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
    public class AdminExpositoresController : Controller
    {
        u535755128_AngularviewContext _context;
        public AdminExpositoresController(u535755128_AngularviewContext context)
        {
            _context = context;
        }
        // GET: AdminExpositoresController
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: AdminExpositoresController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            return View(await _context.ProductoServicio.FindAsync(id));
        }


        // GET: AdminExpositoresController/Create
        public IActionResult Login()
        {
            return View();
        }

        // POST: AdminExpositoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ModelLoginExpoxitor model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var expos = await _context.Expositor.Where(d => d.Correo.Equals(model.Correo)).ToListAsync();
                    if (expos.Count == 1)
                    {
                        if (!string.IsNullOrEmpty(expos[0].Password))
                        {
                            if (expos[0].Password.Equals(model.Pass))
                            {
                                HttpContext.Session.SetString("id", expos[0].Id.ToString());
                                HttpContext.Session.SetString("nombre", expos[0].Nombre);
                                HttpContext.Session.SetString("tipo", "expo");
                                return Redirect(Url.Action("Admin"));
                            }
                            else
                            {
                                model.Coreect = false;
                                model.Mensaje = "Error de contraseña";
                                return View(model);
                            }
                        }
                        else
                        {
                            var ds = await _context.VentaEspacio.Where(d => d.Estatus == 2 && d.IdExpositor == expos[0].Id).ToListAsync();
                            if (ds.Count>0)
                            {
                                HttpContext.Session.SetString("id", expos[0].Id.ToString());
                                HttpContext.Session.SetString("nombre", expos[0].Nombre);
                                HttpContext.Session.SetString("tipo", "new");
                                return View("HolaAngularView", expos[0]); 
                            }
                            else
                            {
                                model.Coreect = false;
                                model.Mensaje = "Aun no cuentas con venta de espacio";
                                return View(model);
                            }
                        }

                    }
                    return View(model);
                }

                return View(model);
            }
            catch
            {

                return View(model);
            }
        }

        // GET: AdminExpositoresController/Edit/5
        public ActionResult HolaAngularView()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HolaAngularView(Expositor model)
        {

            _context.Update(model);
            await _context.SaveChangesAsync();
            return View("Admin");
        }

        public ActionResult Admin()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            return View(await _context.ProductoServicio.FindAsync(id));
        }

        // POST: AdminExpositoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoServicio model)
        {
            try
            {
                _context.ProductoServicio.Update(model);
                await _context.SaveChangesAsync();
                return View();
            }
            catch
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Productos()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            string id = HttpContext.Session.GetString("id");
            List<ProductoServicio> model = await _context.ProductoServicio.Where(f => f.IdExpositor == Convert.ToInt32(id)).ToListAsync();
            return View(model);
        }

        // GET: AdminExpositoresController/Delete/5
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expositor = await _context.Expositor.FindAsync(id);
            _context.Expositor.Remove(expositor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminExpositoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoServicio model)
        {
            try
            {

                if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
                {
                    return Redirect(Url.ActionLink("Expo", "Home"));
                }
                string id = HttpContext.Session.GetString("id");

                model.Activo = 1;
                model.Modificado = DateTime.Now;
                model.IdExpositor = Convert.ToInt32(id);

                _context.Add(model);
                await _context.SaveChangesAsync();

                List<ProductoServicio> modelList = await _context.ProductoServicio.Where(f => f.IdExpositor == Convert.ToInt32(id)).ToListAsync();
                return View("Productos", modelList);
            }
            catch
            {
                return View("Admin");
            }
        }
    }
}
