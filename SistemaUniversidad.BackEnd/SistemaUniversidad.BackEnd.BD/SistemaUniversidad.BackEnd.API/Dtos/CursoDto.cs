using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class CursoDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreCurso { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal? Precio { get; set; }

        public bool? Activo { get; set; }
    }
}
