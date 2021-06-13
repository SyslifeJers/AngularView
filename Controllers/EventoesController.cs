using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularView.Models;
using Microsoft.AspNetCore.Http;
using AngularView.Models.ViewModels;

namespace AngularView.Controllers
{
    public class EventoesController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public EventoesController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: Eventoes
        public async Task<IActionResult> Index(AltaExpoFreelance model)
        {
            model.GetEventos = await _context.Evento.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Salas(AltaExpoFreelance model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            model.GetSalas = await _context.Sala.Include(d => d.Caja).Where(f => f.IdEvento == model.idevento).ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Cajas(AltaExpoFreelance model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            model.GetCajas = await _context.Caja.Where(f => f.IdSala == model.idSalas).ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> TomarCajon(AltaExpoFreelance model)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("nombre")))
            {
                return Redirect(Url.ActionLink("Index", "Home"));
            }
            var klist = _context.Expositor.Where(r => r.Id==model.Id).ToList();

            int id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (ModelState.IsValid)
            {

                var coaka = _context.Caja.Find(model.idCajas);
                coaka.Ocupado = 1;
                _context.Update(coaka);

                VentaEspacio ventaEspacio = new VentaEspacio();
                ventaEspacio.Fecha = DateTime.Now;
                ventaEspacio.IdCajon = coaka.Id;
                ventaEspacio.IdVendedor = id;
                ventaEspacio.IdExpositor = klist[0].Id;
                ventaEspacio.Total = Convert.ToDecimal(coaka.Costo);
                ventaEspacio.Estatus = 1;
                _context.VentaEspacio.Add(ventaEspacio);
                _context.SaveChanges();

                Herramientas.Correo(klist[0].Correo, "Pago de espacio en AngularView", cuerpo(klist[0].Nombre, coaka.Descripcion+" Espacio", klist[0].Correo, klist[0].Negocio));

                return View("DetallesAlta", _context.VentaEspacio.Include(
                    d => d.IdExpositorNavigation).Include(d => d.IdCajonNavigation).Where(l => l.IdVendedor == id).ToList().OrderBy(f => f.Fecha));
            }


            return View(model);
        }
        private string cuerpo(string Nombre, string NombreCajon, string Correo, string Negocio)
        {
            string cuper = "<!DOCTYPE html> " +
                "<html>" +
                "<head>" +
                    "<title>Email</title>" +
                "</head>" +
                "<body style=\"font-family:'Century Gothic'\">" +
                    "<h1 style=\"text-align:center;\"> ¡Hola " + Nombre + "!</h1>" +
                    "< BR >< BR > <P> Los vendedores en ningún momento pedirán anticipo</ P > " +
                    $"<h3>Tu reserva del espacio es " + NombreCajon + "</h3>" +
                        $"Correo : {Correo}  <br />" +
                        "Contraseña : Se le enviará un link inteligente para generar su contraseña una vez confirmado el pago<br />" +
                        $"Empresa : {Negocio} <br />" +
                        $"<h3>Instruciones de pago</h3>" +
                           $"<p>El pago es por tranferencia bancaria </p>" +
  "<P> Banco: BBVA </ P >" +
       "<P> Clave: 012 580 00135237556 6 </ P >" +
        "    <P> Tarjeta: 4152 3134 7441 0128 </ P >" +
                "    <P> Nombre: JORGE ABRAHAM ALVARADO DANIEL </ P >" +
         "        <P>" +
          "        </P>" +
           "       <P> Una vez realizado el pago deberá enviar el ticket de compra, al correo jorge.alvarado@aldacomp.com " +
                            "para su validación y activación a su perfil al expo. Recibirá un" +
"correo donde se le dará acceso para dar de alta sus productos.</ P >" +
" <P><a href=\"mail:jorge.alvarado@aldacomp.com\" class=\"btn btn-info\" > ¿Requieres facturación?</ P > " +
                "</body>" +
                "</html>";
            return cuper;
        }
        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Evento.FindAsync(id);
            _context.Evento.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.Id == id);
        }
    }
}
