using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Views
{
    public class AdministradorKeyController : Controller
    {
        // GET: AdministradorKeyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdministradorKeyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministradorKeyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministradorKeyController/Create
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

        // GET: AdministradorKeyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministradorKeyController/Edit/5
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

        // GET: AdministradorKeyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministradorKeyController/Delete/5
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
