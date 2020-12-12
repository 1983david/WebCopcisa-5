using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCopcisa.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }

        void Save();
    }
}
