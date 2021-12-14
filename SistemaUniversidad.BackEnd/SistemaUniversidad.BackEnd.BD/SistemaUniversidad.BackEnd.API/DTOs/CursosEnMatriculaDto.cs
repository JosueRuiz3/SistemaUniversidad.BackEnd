using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class CursosEnMatriculaDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Número Matrícula")]
        public int NumeroMatricula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Código Curso")]
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Número Ciclo")]
        public int NumeroCiclo { get; set; }
    }
}
