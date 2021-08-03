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
        public async Task<IActionResult> MisInteresados()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            string id = HttpContext.Session.GetString("id");
            ModelVentas modelVentas = new ModelVentas();
            //modelVentas.clickProdcutos = await _context.ClickProdcuto.Where(d=>d.IdProductoNavigation.IdExpositor == Convert.ToInt32(id)).ToListAsync();
            //va
            //modelVentas.clickCajas = await _context.ClickCajas.Where(d => d.IdCajaNavigation. == Convert.ToInt32(id)).ToListAsync();
            return View(modelVentas);
        }
        public IActionResult CambiarLogo(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            return View(new ModelArchivo() { id_Producto = id });
        }
        public async Task<IActionResult> SubirEnvio(string name)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
             var IdExpositor = Convert.ToInt32(HttpContext.Session.GetString("id"));
            var list = await _context.Expositor.FindAsync(IdExpositor);
            if (list != null)
            {
                bool agregar = true;
                foreach (var item in list.TipoEnvio)
                {
                    if (!item.Nombre.Equals(name))
                    {
                        agregar = false;
                    }

                }
                if (agregar)
                {
                    TipoEnvio tipoPago = new TipoEnvio()
                    {
                        IdExpo = IdExpositor,
                        Nombre = name
                    };
                    _context.TipoEnvio.Add(tipoPago);
                    await _context.SaveChangesAsync();
                }
                
            }
            return View();
        }        public async Task<IActionResult> SubirPago(string name)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
             var IdExpositor = Convert.ToInt32(HttpContext.Session.GetString("id"));
            var list = await _context.Expositor.FindAsync(IdExpositor);
            if (list != null)
            {
                bool agregar = true;
                foreach (var item in list.TipoPago)
                {
                    if (!item.Nombre.Equals(name))
                    {
                        agregar = false;
                    }

                }
                if (agregar)
                {
                    TipoPago tipoPago = new TipoPago()
                    {
                        IdExpo = IdExpositor,
                        Nombre = name
                    };
                    _context.TipoPago.Add(tipoPago);
                    await _context.SaveChangesAsync();
                }
                
            }
            return Redirect(Url.Action("MisCajones"));
        }

        public IActionResult Registro()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(Expositor model)
        {
            model.Activo = 1;
            model.Registro = DateTime.Now;
            model.Modificado = DateTime.Now;

            if (String.IsNullOrEmpty(model.Negocio))
            {
                model.Token = "Ups, no pordemos dejar vacío Negocio";
                return View(model);
            }
            if (String.IsNullOrEmpty(model.Nombre))
            {
                model.Token = "Ups, no pordemos dejar vacío Nombre";
                return View(model);
            }
            if (String.IsNullOrEmpty(model.Apellidos))
            {
                model.Token = "Ups, no pordemos dejar vacío Apellido";
                return View(model);
            }
            if (String.IsNullOrEmpty(model.Correo))
            {
                model.Token = "Ups, no pordemos dejar vacío Correo";
                return View(model);
            }
            var klist = _context.Expositor.Where(r => r.Correo.Equals(model.Correo)).ToList();
            if (klist.Count() != 0)
            {
                model.Token = "El correo ya esta registrado";
                return View(model);
            }
            _context.Expositor.Add(model);
            _context.SaveChanges();

            return Redirect(Url.Action("Login"));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarLogo(ModelArchivo model)
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
                        var uploads = Path.Combine(hostingEnvironment.WebRootPath, "Img/Logos");
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

                        return Redirect(Url.ActionLink("MisCajones"));
                    }
                    catch (Exception)
                    {


                        ModelArchivo modelArcsahivo = new ModelArchivo()
                        {
                            id_Producto = model.id_Producto,
                            mensaje = "Seguimos en proceso con la anterior imagen intente mas tarde"
                        };
                        return View(modelArcsahivo);
                    }
                }
            }


            return Redirect(Url.ActionLink("MisCajones"));
        }
        public IActionResult ActualizarCajonDatos(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            return View(_context.DetalleCaja.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarCajonDatos(DetalleCaja model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            model.Modificado = DateTime.Now;
            _context.DetalleCaja.Update(model);
            await _context.SaveChangesAsync();
            return Redirect(Url.ActionLink("MisCajones"));
        }
        public IActionResult ActualizarDatos(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }

            return View(new DetalleCaja() { IdCaja = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarDatos(DetalleCaja model)
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
        public async Task<IActionResult> MisCajones()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            string id = HttpContext.Session.GetString("id");
            Expositor expositor = await _context.Expositor.FindAsync(id);
            
            List<DetalleCaja> sds = await _context.DetalleCaja.Include(d => d.IdCajaNavigation).Where(d => d.IdExpositor == Convert.ToInt32(id)).ToListAsync();
            List<VentaEspacio> ventC = await _context.VentaEspacio.Include(d => d.IdCajonNavigation).Where(d => d.IdExpositor == Convert.ToInt32(id) && d.Estatus == 2).ToListAsync();
            List<ModelDetalleCajon> modelDetalleCajons = new List<ModelDetalleCajon>();
            
            

            if (ventC.Count != 0)
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

            if (modelDetalleCajons.Count>0)
            {
                modelDetalleCajons[0].listTipoPago = expositor.TipoPago.ToList();
                modelDetalleCajons[0].listTipoEnvio = expositor.TipoEnvio.ToList();
            }

            return View(modelDetalleCajons);
        }

        // GET: AdminExpositoresController/Details/5
        public async Task<IActionResult> Details(int id)
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
                            if (ds.Count > 0)
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
        public IActionResult HolaAngularView()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HolaAngularView(Expositor model)
        {
            model.Modificado = DateTime.Now;
            model.Activo = 1;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return View("Admin");
        }

        public IActionResult Admin()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
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
            ModelListproduct modelsda = new ModelListproduct()
            {
                productoServicios = model,
                rut = pathBase
            };
            return View(modelsda);
        }

        // GET: AdminExpositoresController/Delete/5
        public IActionResult Create()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("tipo")))
            {
                return Redirect(Url.ActionLink("Expo", "Home"));
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
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
                if (model.Descuento ==1)
                {
                    if (model.PrecioNormal !=null)
                    {

                        if (model.PrecioDescuento !=null&& model.PrecioDescuento > 0)
                        {
                            if (true)
                            {
                                model.PrecioDescuento = model.PrecioNormal - ((model.PrecioNormal * model.PrecioDescuento) / 100);
                            }
                        }
                    } 
                }
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
        public async Task<IActionResult> SubirImagen(ModelArchivo model)
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

            ModelArchivo modelArchivo = new ModelArchivo()
            {
                id_Producto = model.id_Producto,
                productoServicio = _context.ProductoServicio.Find(model.id_Producto)
            };
            return View(modelArchivo);
        }

        public IActionResult SubirImagen(int id)
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
        public async Task<IActionResult> Salas(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            return View(await _context.Sala.Include(d => d.Caja).Where(f => f.IdEvento == id).ToListAsync());
        }
        public async Task<IActionResult> Cajas(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            var list = await _context.Caja.Where(f => f.IdSala == id).OrderBy(d => d.Descripcion).ToListAsync();
            List<Caja> cajas = new List<Caja>();
            List<int> cvr = new List<int>();

            foreach (var item in list)
            {
                cvr.Add(Convert.ToInt32(item.Descripcion));
            }
            var lisorede = cvr.OrderBy(d => d).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                foreach (var item in list)
                {
                    if (lisorede[i].ToString().Equals(item.Descripcion))
                    {
                        cajas.Add(item);
                    }
                }
            }
            return View(cajas);
        }
        public async Task<IActionResult> TomarCaja(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }

            int idExpo = Convert.ToInt32(HttpContext.Session.GetString("id"));
            var expo = _context.Expositor.Find(idExpo);
                var coaka = _context.Caja.Find(id);
                coaka.Ocupado = 1;
                _context.Update(coaka);


                VentaEspacio ventaEspacio = new VentaEspacio();
                ventaEspacio.Fecha = DateTime.Now;
                ventaEspacio.IdCajon = id;
                ventaEspacio.IdVendedor =3;
                ventaEspacio.IdExpositor = idExpo;
                ventaEspacio.Total = Convert.ToDecimal(coaka.Costo);
                ventaEspacio.Estatus = 1;
                _context.VentaEspacio.Add(ventaEspacio);
                _context.SaveChanges();

                Herramientas.Correo(expo.Correo, "Pago de espacio en AngularView", "<!DOCTYPE html> " +
                "<html>" +
                "<head>" +
                    "<title>Email</title>" +
                "</head>" +
                "<body style=\"font-family:'Century Gothic'\">" +
                    "<h1 style=\"text-align:center;\"> ¡Hola " + expo.Nombre + "!</h1>" +
                    "<P> Los vendedores en ningun momento pediran anticipo</ P > " +
                    $"<h3>Tu reserva del espacio es " + coaka.Descripcion + "</h3>" +
                        $"Correo : {expo.Correo}  <br />" +
                        "Contraseña : Se le enviara un link inteligente para generar su contraseña una vez confirmado el pago<br />" +
                        $"Empresa : {expo.Negocio} <br />" +
                        $"<h3>Intruciones de pago</h3>" +
                           $"<p>El pago es por tranferencia bancaria </p>" +
  "<P> Banco: BBVA </ P >" +
       "<P> Clave: 012 580 00135237556 6 </ P >" +
        "    <P> Tarjeta: 4152 3134 7441 0128 </ P >" +
                "    <P> Nombre: JORGE ABRAHAM ALVARADO DANIEL </ P >" +
         "        <P>" +
          "        </P>" +
           "       <P> Una vez realizado el pago deberá enviar el ticket de compra, al correo jorge.alvarado@aldacomp.com" +
                            "para su validación y activación a su perfil al expo. Recibirá un" +
"correo donde se le dará acceso para dar de alta sus productos.</ P >" +
"<P><a href=\"mailto:jorge.alvarado@aldacomp.com\" class=\"btn btn-info\" > ¿Requieres facturación?</ P > " +
                "</body>" +
                "</html>");

                return Redirect(Url.Action("Admin"));

        }
    }
}
