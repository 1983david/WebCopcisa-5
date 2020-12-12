using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCopcisa.Data.Repository;
using WebCopcisa.Entities;

namespace WebCopcisa.Data
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepository (ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaCategoria()
        {
            return _db.Categoria.Select(i => new SelectListItem() { 
                Text = i.Nombre,
                Value = i.id.ToString()
            });
        }

        public void Update(Categoria categoria)
        {
            var objDesdeDB = _db.Categoria.FirstOrDefault(s=> s.id == categoria.id);
            objDesdeDB.Nombre = categoria.Nombre;
            objDesdeDB.Orden = categoria.Orden;
            _db.SaveChanges();
        }
    }
}
