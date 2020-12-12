using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCopcisa.Entities
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Nombre de la Categoría")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Orden de visualizacion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Orden { get; set; }

    }
}
