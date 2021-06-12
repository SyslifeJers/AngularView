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
            return View(await _context.Sala.Include(d => d.Caja).Where(f => f.IdEvento == 1).ToListAsync());
        }

        // GET: ExpoController/Details/5
        public async Task<ActionResult> Cajones(int id)
        {
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

        public async Task<ActionResult> DetalleCajon(int id)
        {
            List<DetalleCaja> detalleCajas = await _context.DetalleCaja.Where(d => d.IdCaja == id).Include(d => d.IdExpositorNavigation).ToListAsync();

            if (detalleCajas.Count!=0)
            {
                ModelDetalleCajon modelDetalleCajon = new ModelDetalleCajon()
                {
                    SiDAtos = true,
                    listProductoServicios = await _context.ProductoServicio.Where(d => d.IdExpositor == detalleCajas[0].IdExpositor).ToListAsync(),
                    detalleCaja = detalleCajas[0]
                };
                return View(modelDetalleCajon);
            }
            return View(new ModelDetalleCajon() { SiDAtos = false }) ; 
        }
        public async Task<ActionResult> DetalleProducto(int id)
        {
            return View(await _context.ProductoServicio.Where(f => f.Id == id).ToListAsync());
        }

    }
}
