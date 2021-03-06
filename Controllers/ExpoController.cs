using AngularView.Models;
using AngularView.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Controllers
{
    public class ExpoController : Controller
    {
        private readonly u535755128_AngularviewContext _context;
        private readonly IMapper _mapper;
        public ExpoController(u535755128_AngularviewContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: ExpoController
        public async Task<ActionResult> Index()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("IndexSucces"));
            }
            return View(await _context.Sala.Include(d => d.Caja).Where(f => f.IdEvento == 1).ToListAsync());
        }

        // GET: ExpoController/Details/5
        public async Task<ActionResult> Cajones(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            var list = await _context.Caja.Where(f => f.IdSala == id).OrderBy(d => d.Descripcion).ToListAsync();
            var listDetalle = await _context.DetalleCaja.ToListAsync();
            List<Caja> cajas = new List<Caja>();
            List<ModelCajasExpo> modelcajas = new List<ModelCajasExpo>();
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
                        modelcajas.Add(new ModelCajasExpo() { caja = item });
                    }
                }
            }
            foreach (var item in modelcajas)
            {
                foreach (var itemcaja in listDetalle)
                {

                    if (itemcaja.IdCaja == item.caja.Id)
                    {
                        item.Exitente = true;
                        item.detalleCaja = itemcaja;
                    }
                }
            }
            return View(modelcajas);
        }

        public async Task<ActionResult> DetalleProducto(int id)
        {
            return View(await _context.ProductoServicio.Where(f => f.Id == id).ToListAsync());
        }
        public async Task<ActionResult> ModuloInformacion()
        {
            return View();
        }

        public async Task<ActionResult> DetalleCajonMovil(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            List<DetalleCaja> sds = await _context.DetalleCaja.Include(d => d.IdCajaNavigation).Where(d => d.IdCaja == Convert.ToInt32(id)).ToListAsync();
            ModelDetalleCajon modelDetalleCajons = new ModelDetalleCajon()
            {
                detalleCaja = sds[0],
                SiDAtos = true,
                listProductoServicios = await _context.ProductoServicio.Where(d => d.IdExpositor == sds[0].IdExpositor).ToListAsync()
            };
            ViewData["TipoEnvio"] = new SelectList(_context.TipoEnvio, "Id", "Nombre");
            ViewData["TipoPago"] = new SelectList(_context.TipoPago, "Id", "Nombre");
            modelDetalleCajons.listProductSelected = new List<ModelSelect>();
            foreach (var item in modelDetalleCajons.listProductoServicios)
            {
                modelDetalleCajons.listProductSelected.Add(new ModelSelect()
                {
                    Selected = false,
                    Cant = 0,
                    IdProduct = item.Id,
                    Producto = item.Nombre

                });
            }

            return View(modelDetalleCajons);
        }
        public async Task<ActionResult> DetalleCajon(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            List<DetalleCaja> sds = await _context.DetalleCaja.Include(d => d.IdCajaNavigation).Where(d => d.IdCaja == Convert.ToInt32(id)).ToListAsync();
            ModelDetalleCajon modelDetalleCajons = new ModelDetalleCajon()
            {
                detalleCaja = sds[0],
                SiDAtos = true,
                listProductoServicios = await _context.ProductoServicio.Where(d => d.IdExpositor == sds[0].IdExpositor).ToListAsync()
            };
            ViewData["TipoEnvio"] = new SelectList(_context.TipoEnvio, "Id", "Nombre");
            ViewData["TipoPago"] = new SelectList(_context.TipoPago, "Id", "Nombre");
            modelDetalleCajons.listProductSelected = new List<ModelSelect>();
            foreach (var item in modelDetalleCajons.listProductoServicios)
            {
                modelDetalleCajons.listProductSelected.Add(new ModelSelect()
                {
                    Selected = false,
                    Cant = 0,
                    IdProduct = item.Id,
                    Producto = item.Nombre

                });
            }

            return View(modelDetalleCajons);
        }
        public async Task<ActionResult> GoVenta(ModelDetalleCajon model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            if (model.listProductSelected.Count==0)
            {
                return Redirect(Url.ActionLink("detallecajon", "Expo", new { id = model.detalleCaja.Id }));
            }
            var id = HttpContext.Session.GetInt32("Cliente");
            model.GetClientes = _context.Clientes.Find(id);

            var detalleC = await _context.DetalleCaja.FindAsync(model.detalleCaja.Id);
            model.detalleCaja = detalleC;
            var expositor = await _context.Expositor.Include(s => s.ProductoServicio).Include(d => d.TipoEnvio).Include(d => d.TipoPago).Where(d => d.Id == model.IdExpositor).FirstOrDefaultAsync();
            ViewData["TipoEnvio"] = new SelectList(expositor.TipoEnvio, "Id", "Nombre");
            ViewData["TipoPago"] = new SelectList(expositor.TipoPago, "Id", "Nombre");
            model.GetExpositor = expositor;
            model.IdExpositor = expositor.Id;
            var correo = HttpContext.Session.GetString("ClienteCorreo");
            string listpro = "";
            double sum = 0;

            foreach (var item in model.listProductSelected)
            {
                if (item.Selected)
                {
                    try
                    {
                        var res = expositor.ProductoServicio.Where(d => d.Id == item.IdProduct).FirstOrDefault();
                        listpro += "<tr><td >" + item.Cant + " </td><td>" + res.Decripcion + "</td><td>" + Convert.ToDouble(res.PrecioNormal).ToString("c") + "</td></tr> ";


                        if (res.Descuento == 1 && res.PrecioNormal != null)
                        {
                            sum += item.Cant * (double)res.PrecioNormal;
                        }
                        else
                        {
                            if (res.PrecioNormal != null)
                            {
                                sum += item.Cant * (double)res.PrecioNormal;
                            }

                        }
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            model.Total = sum;
            model.Iva = sum * .16;
            model.listpro = listpro;
            //            Herramientas.Correo(expositor.Correo, "Venta de AngularView", "<!DOCTYPE html> " +
            //"<html>" +
            //"<head>" +
            //   "<title>Email</title>" +
            //"</head>" +
            //"<body style=\"font-family:'Century Gothic'\">" +
            //"<h1>Prueba</h1>" +
            //" <table class=\"defaul\" border =\"1\" style = \"width: 30em\"> " +
            //"<tr style=\"background - color: cornflowerblue\" > " +
            //" <td style=\"text - align:center\" > Cliente</td>" +
            //" </tr>" +
            //" <tr>" +
            //" <td>" +
            //"Razón social: "+ model.razonSocial + "<br>" +
            //" RFC:"+ model.RFC+"<br>" +
            //"  Dirección:"+model.Direccion+" <br>" +
            //"Teléfono:"+model.Telefono+"<br>" +
            //"  Correo electrónico: " + correo +
            //" </td>" +
            //"   </tr>" +
            //" </table>" +
            //"  <br>" +
            //"  <table class=\"defaul\"border =\"1\" style = \"width: 30em\" > " +
            //" <tr style=\"background - color: cornflowerblue\" > " +
            //" <td style=\"text - align:center\" > Proovedor</td>" +
            //" </tr>" +
            //"  <tr>" +
            //"<td>" +
            //"Razón social: "+expositor.Nombre+"<br>" +
            //" RFC: (RFC del proveedor)<br>" +
            //" Dirección: (Dirección del proveedor)<br>" +
            //"Teléfono: " + expositor.Celular + "<br>" +
            //" Correo electrónico: " + expositor.Correo + "" +
            //"</td>" +
            //"  </tr>" +
            //" </table>" +
            //" <br>" +
            // " <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +
            // "      <tr style = \"background - color: cornflowerblue\" > " +
            //"         <td style=\"width: 4em\" > Cantidad</td>" +
            //"        <td style = \"width: 18em\" > Descripción del Servicio</td>" +
            //"       <td> Precio Unitario</td>" +
            //"       </tr>" +

            //"  <tr>" +
            //"          <td>" +
            //"         </td>" +
            //"        <td>" +
            //            listpro    +
            //"      </td>" +
            //"     <td style = \"text - align:center\" > " +
            //"        0.00" +
            //"   </td >" +
            //"</tr >" +
            //"</table >" +
            //" <table class=\"defaul\">" +
            //"    <tr>" +
            //"       <td style = \"width: 19em\" > " +

            //"      <td >" +
            //"     <td >" +
            //"        Subtotal" +
            //"       <br >" +
            //"      I.V.A." +
            //"    <br >" +
            //"               Total" +
            //"          </td >" +
            //"         <td style=\"text - align:center\" > " +
            //sum +
            //"           <br>" +
            //(sum*.16).ToString() +
            //"         <br>" +
            //(sum * .16 + sum).ToString() +
            //"   </td>" +
            //"        </tr>" +
            //"    </table>" +
            //"    <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +

            //"       <tr style = \"background - color: cornflowerblue\" >" +

            //"            <td style=\"text - align:center\" > Observaciones</td>" +
            //"        </tr>" +
            //"        <tr>" +
            //"           <td>"+
            //"              (Cuestiones a considerar, tanto para el cliente como para el proveedor, como condiciones de pago<br>"+
            //"             y entrega, forma en que se proveerá el servicio, fecha y lugar, etcétera)"+
            //"        </td>"+
            //"   </tr>"+
            //"    </table>"+
            //"    <table class=\"defaul\" > " +

            //"        <tr>"+
            //"            <td style = \"text-align:center\" > _________________________ <td >" +

            //"            <td style=\"text-align:center\" > _________________________</td>" +
            //"        </tr>"+

            //"        <br> <br>"+

            //"        <tr style = \"width: 3em\" >" +
            //"            <td ><td >"+

            // "           <td ><td >"+
            //"        <tr >"+

            //"        <tr >"+
            //"            <td style=\"text-align:center\" > " +
            //"                Cliente<br>"+
            //"                (Nombre y firma del cliente)"+
            //"            </td>"+
            //"            <td style = \"text-align:center\" >" +
            //"                Proveedor<br>"+
            //"                (Nombre y firma del proveedor)"+

            //"            </td >"+
            //"       </tr >"+

            //"    <table >"+



            //"</body>" +
            //"</html>");


            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateVenta(ModelDetalleCajon model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            var id = HttpContext.Session.GetInt32("Cliente");
            model.GetClientes = _context.Clientes.Find(id);

            var detalleC = await _context.DetalleCaja.FindAsync(model.detalleCaja.Id);
            var expositor = await _context.Expositor.Include(s => s.ProductoServicio).Include(d => d.TipoEnvio).Include(d => d.TipoPago).Where(d => d.Id == model.IdExpositor).FirstOrDefaultAsync();
            model.GetExpositor = expositor;
            var correo = HttpContext.Session.GetString("ClienteCorreo");
            string listpro = "";
            double sum = 0;
            List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
            foreach (var item in model.listProductSelected)
            {
                if (item.Selected)
                {
                    try
                    {
                        var res = expositor.ProductoServicio.Where(d => d.Id == item.IdProduct).FirstOrDefault();

                        listpro += "<tr><td >" + item.Cant + " </td><td>" + res.Decripcion + "</td><td>" + Convert.ToDouble(res.PrecioNormal).ToString("c") + "</td></tr> ";


                        if (res.Descuento == 1 && res.PrecioNormal != null)
                        {

                            detalleVentas.Add(new DetalleVenta()
                            {
                                Descripcion = res.Nombre,
                                Subtotal = ((decimal)res.PrecioNormal * Convert.ToDecimal(item.Cant)).ToString(),
                                Cant = item.Cant
                            });
                            sum += item.Cant * (double)res.PrecioNormal;
                        }
                        else
                        {
                            if (res.PrecioNormal != null)
                            {
                                detalleVentas.Add(new DetalleVenta()
                                {
                                    Descripcion = res.Nombre,
                                    Subtotal = ((decimal)res.PrecioDescuento * Convert.ToDecimal(item.Cant)).ToString(),
                                    Cant = item.Cant
                                });
                                sum += item.Cant * (double)res.PrecioDescuento;
                            }
                            else
                            {


                                    detalleVentas.Add(new DetalleVenta()
                                    {
                                        Descripcion = res.Nombre,
                                        Subtotal = "0",
                                        Cant = item.Cant
                                    });
                                    sum += item.Cant * (double)res.PrecioNormal;

                            }

                        }
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            model.Total = sum;
            model.Iva = sum * .16;
            model.listpro = listpro;
            TipoEnvio tipoe = await _context.TipoEnvio.FindAsync(model.TipoEnvio);
            TipoPago tipop = await _context.TipoPago.FindAsync(model.TipoPago);
            Venta venta = new Venta()
            {
                IdCliente = (int)id,
                DireccionClient = model.Direccion,
                Fecha = DateTime.Now,
                IdExpositor = model.IdExpositor,
                Observaciones = model.observaciones,
                Rfccliente = model.RFC,
                Rzcliente = model.razonSocial,
                Telefono = model.Telefono,
                TipoEnvio = tipoe.Nombre,
                TipoPago = tipop.Nombre,
                Activo = 1,
                ExpoRfc = model.detalleCaja.Rfc,
                ExpoCelular = expositor.Celular,
                ExpoCorreo = expositor.Correo,
                ExpoDireccion = model.detalleCaja.Direccion,
                ExpoRz = model.detalleCaja.RazonSocial,
                Total = model.Total.ToString("c"),
                
            };
            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();
            foreach (var item in detalleVentas)
            {
                item.IdOrden = venta.Id;
            }
            _context.DetalleVenta.AddRange(detalleVentas);
            await _context.SaveChangesAsync();
            Herramientas.Correo(expositor.Correo, "Venta de AngularView", "<!DOCTYPE html> " +
"<html>" +
"<head>" +
   "<title>Email</title>" +
"</head>" +
"<body style=\"font-family:'Century Gothic'\">" +
"<h1>Prueba</h1>" +
" <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +
"<tr style=\"background - color: cornflowerblue\" > " +
" <td style=\"text - align:center\" > Cliente</td>" +
" </tr>" +
" <tr>" +
" <td>" +
"Razón social: " + model.razonSocial + "<br>" +
" RFC:" + model.RFC + "<br>" +
"  Dirección:" + model.Direccion + " <br>" +
"Teléfono:" + model.Telefono + "<br>" +
"  Correo electrónico: " + correo +
" </td>" +
"   </tr>" +
" </table>" +
"  <br>" +
"  <table class=\"defaul\"border =\"1\" style = \"width: 30em\" > " +
" <tr style=\"background - color: cornflowerblue\" > " +
" <td style=\"text - align:center\" > Proovedor</td>" +
" </tr>" +
"  <tr>" +
"<td>" +
"Razón social: " + expositor.Nombre + "<br>" +
" RFC: <br>" +
" Dirección: <br>" +
"Teléfono: " + expositor.Celular + "<br>" +
" Correo electrónico: " + expositor.Correo + "" +
"</td>" +
"  </tr>" +
" </table>" +
" <br>" +
 " <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +
 "      <tr style = \"background - color: cornflowerblue\" > " +
"         <td style=\"width: 4em\" > Cantidad</td>" +
"        <td style = \"width: 18em\" > Descripción del Servicio</td>" +
"       <td> Precio Unitario</td>" +
"       </tr>" +

listpro +
"<table >" +
" <table class=\"defaul\">" +
"    <tr>" +
"       <td style = \"width: 19em\" > " +

"      <td >" +
"     <td >" +
"        Subtotal" +
"       < br >" +
"      I.V.A." +
"    < br >" +
"               Total" +
"          <td >" +
"         <td style=\"text - align:center\" > " +
(model.Total - model.Iva).ToString("c") +
"           " +
(model.Iva).ToString("c") +
"         " +
(model.Total).ToString("c") +
"   </td>" +
"        </tr>" +
"    </table>" +
"    <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +

"       <tr style = \"background - color: cornflowerblue\" >" +

"            <td style=\"text - align:center\" > Observaciones</td>" +
"        </tr>" +
"        <tr>" +
"           <td>" +
"              (Cuestiones a considerar, tanto para el cliente como para el proveedor, como condiciones de pago<br>" +
"             y entrega, forma en que se proveerá el servicio, fecha y lugar, etcétera)" +
"        </td>" +
"   </tr>" +
"    </table>" +
"    <table class=\"defaul\" > " +

"        <tr>" +
"            <td style = \"text-align:center\" > _________________________ <td >" +

"            <td style=\"text-align:center\" > _________________________</td>" +
"        </tr>" +

"        <br> <br>" +

"        <tr style = \"width: 3em\" >" +
"            <td ><td >" +

 "           <td ><td >" +
"        <tr >" +

"        <tr >" +
"            <td style=\"text-align:center\" > " +
"                Cliente<br>" +
"                (Nombre y firma del cliente)" +
"            </td>" +
"            <td style = \"text-align:center\" >" +
"                Proveedor<br>" +
"                (Nombre y firma del proveedor)" +

"            <td >" +
"       <tr >" +

"    <table >" +



"</body>" +
"</html>");



            return Redirect(Url.ActionLink("detallecajon","Expo", new { id = model.detalleCaja.Id }));
        }

        //            Herramientas.Correo(expositor.Correo, "Venta de AngularView", "<!DOCTYPE html> " +
        //"<html>" +
        //"<head>" +
        //   "<title>Email</title>" +
        //"</head>" +
        //"<body style=\"font-family:'Century Gothic'\">" +
        //"<h1>Prueba</h1>" +
        //" <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +
        //"<tr style=\"background - color: cornflowerblue\" > " +
        //" <td style=\"text - align:center\" > Cliente</td>" +
        //" </tr>" +
        //" <tr>" +
        //" <td>" +
        //"Razón social: "+ model.razonSocial + "<br>" +
        //" RFC:"+ model.RFC+"<br>" +
        //"  Dirección:"+model.Direccion+" <br>" +
        //"Teléfono:"+model.Telefono+"<br>" +
        //"  Correo electrónico: " + correo +
        //" </td>" +
        //"   </tr>" +
        //" </table>" +
        //"  <br>" +
        //"  <table class=\"defaul\"border =\"1\" style = \"width: 30em\" > " +
        //" <tr style=\"background - color: cornflowerblue\" > " +
        //" <td style=\"text - align:center\" > Proovedor</td>" +
        //" </tr>" +
        //"  <tr>" +
        //"<td>" +
        //"Razón social: "+expositor.Nombre+"<br>" +
        //" RFC: (RFC del proveedor)<br>" +
        //" Dirección: (Dirección del proveedor)<br>" +
        //"Teléfono: " + expositor.Celular + "<br>" +
        //" Correo electrónico: " + expositor.Correo + "" +
        //"</td>" +
        //"  </tr>" +
        //" </table>" +
        //" <br>" +
        // " <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +
        // "      <tr style = \"background - color: cornflowerblue\" > " +
        //"         <td style=\"width: 4em\" > Cantidad</td>" +
        //"        <td style = \"width: 18em\" > Descripción del Servicio</td>" +
        //"       <td> Precio Unitario</td>" +
        //"       </tr>" +

        //"  <tr>" +
        //"          <td>" +
        //"         </td>" +
        //"        <td>" +
        //"               (Características del servicio proporcionado)" +
        //"      </td>" +
        //"     <td style = \"text - align:center\" > " +
        //"        0.00" +
        //"   <td >" +
        //"<tr >" +
        //"<table >" +
        //" <table class=\"defaul\">" +
        //"    <tr>" +
        //"       <td style = \"width: 19em\" > " +

        //"      <td >" +
        //"     <td >" +
        //"        Subtotal" +
        //"       < br >" +
        //"      I.V.A." +
        //"    < br >" +
        //"               Total" +
        //"          <td >" +
        //"         <td style=\"text - align:center\" > " +
        //"            0.00" +
        //"           <br>" +
        //"          0.00" +
        //"         <br>" +
        //"        0.00" +
        //"   </td>" +
        //"        </tr>" +
        //"    </table>" +
        //"    <table class=\"defaul\" border =\"1\" style =\"width: 30em\" > " +

        //"       <tr style = \"background - color: cornflowerblue\" >" +

        //"            <td style=\"text - align:center\" > Observaciones</td>" +
        //"        </tr>" +
        //"        <tr>" +
        //"           <td>"+
        //"              (Cuestiones a considerar, tanto para el cliente como para el proveedor, como condiciones de pago<br>"+
        //"             y entrega, forma en que se proveerá el servicio, fecha y lugar, etcétera)"+
        //"        </td>"+
        //"   </tr>"+
        //"    </table>"+
        //"    <table class=\"defaul\" > " +

        //"        <tr>"+
        //"            <td style = \"text-align:center\" > _________________________ <td >" +

        //"            <td style=\"text-align:center\" > _________________________</td>" +
        //"        </tr>"+

        //"        <br> <br>"+

        //"        <tr style = \"width: 3em\" >" +
        //"            <td ><td >"+

        // "           <td ><td >"+
        //"        <tr >"+

        //"        <tr >"+
        //"            <td style=\"text-align:center\" > " +
        //"                Cliente<br>"+
        //"                (Nombre y firma del cliente)"+
        //"            </td>"+
        //"            <td style = \"text-align:center\" >" +
        //"                Proveedor<br>"+
        //"                (Nombre y firma del proveedor)"+

        //"            <td >"+
        //"       <tr >"+

        //"    <table >"+



        //"</body>" +
        //"</html>");


        //            return View(model);
        //        }


        public async Task<ActionResult> Login()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("IndexSucces"));
            }
            return View();
        }
        public async Task<ActionResult> IndexSucces()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Clientes model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var expos = await _context.Clientes.Where(d => d.Correo.Equals(model.Correo)).ToListAsync();
                    if (expos.Count == 1)
                    {

                        if (expos[0].Contrasena.Equals(model.Contrasena))
                        {
                            var id = expos[0].Id.ToString();
                            HttpContext.Session.SetInt32("Cliente", expos[0].Id);
                            HttpContext.Session.SetString("ClienteCorreo", expos[0].Correo.ToString());
                            return Redirect(Url.Action("IndexSucces"));
                        }
                        else
                        {
                            model.Token = "Error de contraseña";

                        }


                    }
                    model.Token = "Ese correo ya fue registrado";
                    return View(model);
                }

                return View(model);
            }
            catch
            {

                return View(model);
            }
        }
        public async Task<ActionResult> Me()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            var id = HttpContext.Session.GetInt32("Cliente");
            List<Venta> lis = await _context.Venta.Include(d => d.DetalleVenta).Where(d => d.IdCliente == id).ToListAsync();
            MeModel meModel = new MeModel()
            {
                clientes = await _context.Clientes.FindAsync(id),
                ventas = lis
            };
            return View(meModel);
        }
        public async Task<ActionResult> Detalleventa(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            var idclien = HttpContext.Session.GetInt32("Cliente");
            return View(await _context.Venta.Include(d=>d.DetalleVenta).Include(d=>d.IdExpositorNavigation).Where(d=>d.IdCliente == idclien && d.Id == id).FirstOrDefaultAsync());
        }     

        public async Task<ActionResult> AvisoPrivacidad()
        {
            return View();
        }
        public async Task<ActionResult> Terminos()
        {
            return View();
        }
        public async Task<ActionResult> Registro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registro(Clientes model)
        {
            model.Fecha = DateTime.Now;

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
            var klist = _context.Clientes.Where(r => r.Correo.Equals(model.Correo)).ToList();
            if (klist.Count() != 0)
            {
                model.Token = "El correo ya esta registrado";
                return View(model);
            }
            _context.Clientes.Add(model);
            _context.SaveChanges();

            return Redirect(Url.Action("Login"));
        }

    }
}
