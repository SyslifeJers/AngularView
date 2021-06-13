using AngularView.Models;
using AngularView.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Controllers
{
    public class AdminExpositoresController : Controller
    {
        u535755128_AngularviewContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public AdminExpositoresController(u535755128_AngularviewContext context, IHostingEnvironment hosting)
        {
            _context = context;
            hostingEnvironment = hosting;
        }

        public ActionResult ActualizarDatos(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            return View(new DetalleCaja() { IdCaja=id});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActualizarDatos(DetalleCaja model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            model.Modificado = DateTime.Now;
            model.IdExpositor = Convert.ToInt32(HttpContext.Session.GetString("id"));
              _context.DetalleCaja.Add(model);
            await _context.SaveChangesAsync();
            return Redirect(Url.ActionLink("MisCajones"));
        }

        // GET: AdminExpositoresController
        public async Task<ActionResult> MisCajones()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            string id = HttpContext.Session.GetString("id");
            List<DetalleCaja> sds = await _context.DetalleCaja.Include(d=>d.IdCajaNavigation).Where(d => d.IdExpositor == Convert.ToInt32(id)).ToListAsync();
            List<VentaEspacio> ventC = await _context.VentaEspacio.Include(d => d.IdCajonNavigation).Where(d => d.IdExpositor == Convert.ToInt32(id)&&d.Estatus==2).ToListAsync();
            List<ModelDetalleCajon> modelDetalleCajons = new List<ModelDetalleCajon>();
            if (ventC.Count!=0)
            {
                foreach (var item in ventC)
                {
                    bool esta = false;
                    foreach (var item2 in sds)
                    {

                        if (item.IdCajon == item2.IdCaja)
                        {
                            ModelDetalleCajon model = new ModelDetalleCajon();
                            model.SiDAtos = true;
                            model.detalleCaja = sds[0];
                            esta = true;
                            modelDetalleCajons.Add(model);
                        }

                    }
                    if (!esta)
                    {
                        ModelDetalleCajon model = new ModelDetalleCajon();
                        model.SiDAtos = false;
                        model.detalleCaja = new DetalleCaja() { IdCaja = (int)item.IdCajon, IdCajaNavigation = item.IdCajonNavigation };
                        modelDetalleCajons.Add(model);
                    }
                }
               
            }
           
            return View(modelDetalleCajons);
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
            string pathBase = HttpContext.Request.PathBase;
            
            List<ProductoServicio> model = await _context.ProductoServicio.Where(f => f.IdExpositor == Convert.ToInt32(id)).ToListAsync();
            ModelListproduct modelsda = new ModelListproduct() { 
                productoServicios = model,
            rut = pathBase
            };
            return View(modelsda);
        }

        // GET: AdminExpositoresController/Delete/5
        public ActionResult Create()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            return View(await _context.ProductoServicio.FindAsync(id));
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            var prod = await _context.ProductoServicio.FindAsync(id);
            string compa = HttpContext.Session.GetString("id");
            string comdele = prod.IdExpositor.ToString();
            if (comdele.Equals(compa))
            {
                _context.ProductoServicio.Remove(prod);
                await _context.SaveChangesAsync(); 
            }
            return RedirectToAction(nameof(Admin));
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

                List<ProductoServicio> modelsad = await _context.ProductoServicio.Where(f => f.IdExpositor == Convert.ToInt32(id)).ToListAsync();
                ModelListproduct modelsda = new ModelListproduct()
                {
                    productoServicios = modelsad,
                };
                return View("Productos", modelsda);
            }
            catch
            {
                return View("Admin");
            }
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubirImagen(ModelArchivo model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            if (model.File.Length > 0 && model.File.ContentType.Contains("image"))
            {
                if (model.File != null)
                {

                    try
                    {
                        var uniqueFileName = GetUniqueFileName(model.File.FileName);
                        var uploads = Path.Combine(hostingEnvironment.WebRootPath, "Product");
                        var filePath = Path.Combine(uploads, model.id_Producto + ".png");
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                            model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                        }
                        else
                        {
                            model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                        }
                        string id = HttpContext.Session.GetString("id");
                        List<ProductoServicio> modelsad = await _context.ProductoServicio.Where(f => f.IdExpositor == Convert.ToInt32(id)).ToListAsync();
                        ModelListproduct modelsda = new ModelListproduct()
                        {
                            productoServicios = modelsad,
                        };
                        return View("Productos", modelsda);
                    }
                    catch (Exception)
                    {


                        ModelArchivo modelArcsahivo = new ModelArchivo()
                        {
                            id_Producto = model.id_Producto,
                            productoServicio = _context.ProductoServicio.Find(model.id_Producto),
                            mensaje = "Seguimos en proceso con la anterior imagen intente mas tarde"
                        };
                        return View(modelArcsahivo);
                    }
                } 
            }

            ModelArchivo modelArchivo = new ModelArchivo() { 
            id_Producto = model.id_Producto,
            productoServicio = _context.ProductoServicio.Find(model.id_Producto)
            };
            return View(modelArchivo);
        }

        public ActionResult SubirImagen(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            ModelArchivo modelArchivo = new ModelArchivo()
            {
                id_Producto = id,
                productoServicio = _context.ProductoServicio.Find(id)
            };
            return View(modelArchivo);
        }

    }
}
