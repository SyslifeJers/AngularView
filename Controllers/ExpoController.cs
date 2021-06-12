using AngularView.Models;
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
        public ActionResult Cajones(int id)
        {
            return View();
        }

        // GET: ExpoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ExpoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpoController/Edit/5
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

        // GET: ExpoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpoController/Delete/5
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
