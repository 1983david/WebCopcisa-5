using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCopcisa.Data.Repository;
using WebCopcisa.Entities;

namespace WebCopcisa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedortrabajo;
        public CategoriasController(IContenedorTrabajo contenedortrabajo)
        {
            _contenedortrabajo = contenedortrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedortrabajo.Categoria.Add(categoria);
                _contenedortrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria= _contenedortrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedortrabajo.Categoria.Update(categoria);
                _contenedortrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        #region llamadas a la api
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new {data = _contenedortrabajo.Categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objDB = _contenedortrabajo.Categoria.Get(id);
            if (objDB == null)
            {
                return Json(new { success = false, message = "Error Borrardo Categoria" });
            }
            _contenedortrabajo.Categoria.Remove(objDB);
            _contenedortrabajo.Save();
            return Json(new { success = true, message = "Borrado Corectamente" });
        }
        #endregion
    }
}
