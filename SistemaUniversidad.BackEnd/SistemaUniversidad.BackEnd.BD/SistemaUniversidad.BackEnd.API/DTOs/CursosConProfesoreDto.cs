using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.DTOs
{
    public class CursosConProfesoreDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Código Curso")]
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Cédula Profesor")]
        public string CedulaProfesor { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Número Ciclo")]
        public int NumeroCiclo { get; set; }
    }
}
