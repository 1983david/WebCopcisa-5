using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebCopcisa.Data.Repository;
using WebCopcisa.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebCopcisa.Areas.Admin.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;


        public ArticulosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM artivm = new ArticuloVM()
            {
                Articulo = new Entities.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategoria()
            };

            return View(artivm);
        }

    }
}