using AngularView.Models;
using AngularView.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                        modelcajas.Add(new ModelCajasExpo() {caja = item });
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
            modelDetalleCajons.listProductSelected = new List<ModelSelect>();
            foreach (var item in modelDetalleCajons.listProductoServicios)
            {
                modelDetalleCajons.listProductSelected.Add(new ModelSelect()
                {
                    Selected = false,
                    Cant = 0,
                    IdProduct = item.Id,
                    Producto = item.Nombre

                }) ;
            }

            return View(modelDetalleCajons);
        }
        public async Task<ActionResult> GoVenta(ModelDetalleCajon model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Cliente")))
            {
                return Redirect(Url.ActionLink("Login", "Expo"));
            }
            var detalleC = await _context.DetalleCaja.FindAsync(model.detalleCaja.Id);
            var expositor = await _context.Expositor.FindAsync(model.IdExpositor);

            string listpro = "";
            foreach (var item in model.listProductSelected)
            {
                if (item.Selected)
                {
                    listpro += "<p>" + item.Producto + " Cantidad" + item.Cant + "</p> ";
                }
            }

            Herramientas.Correo(expositor.Correo, "Venta de AngularView", "<!DOCTYPE html> " +
"<html>" +
"<head>" +
   "<title>Email</title>" +
"</head>" +
"<body style=\"font-family:'Century Gothic'\">" +
   "<h1 style=\"text-align:center;\"> ¡Hola " + detalleC.Titulo + "!</h1>" +
   "<P> Los vendedores en ningun momento pediran anticipo</ P > " +
   listpro +
"       <P> Una vez realizado el pago deberá enviar el ticket de compra, al correo jorge.alvarado@aldacomp.com" +
           "para su validación y activación a su perfil al expo. Recibirá un" +
"correo donde se le dará acceso para dar de alta sus productos.</ P >" +
"<P><a href=\"mailto:jorge.alvarado@aldacomp.com\" class=\"btn btn-info\" > ¿Requieres facturación?</ P > " +
"</body>" +
"</html>");


            return View(model);
        }


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
                                HttpContext.Session.SetString("Cliente", expos[0].Id.ToString());
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
        public async Task<ActionResult> AvisoPrivacidad()
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
