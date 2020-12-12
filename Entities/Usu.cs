using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCopcisa.Entities
{
    public class Usu
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public int Apellido { get; set; }

        public string FullName => $"{Nombre} {Apellido}";

        public string FullNameWithDocument => $"{Nombre} {Apellido}";
    }

}

