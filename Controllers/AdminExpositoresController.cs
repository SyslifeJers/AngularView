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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminExpositoresController/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: AdminExpositoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(ModelLoginExpoxitor model)
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
                                return Redirect(Url.Action("HolaAngularView")); 
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
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            return View();
        }

        public ActionResult Admin()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            return View();
        }

        // POST: AdminExpositoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AdminExpositoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminExpositoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
