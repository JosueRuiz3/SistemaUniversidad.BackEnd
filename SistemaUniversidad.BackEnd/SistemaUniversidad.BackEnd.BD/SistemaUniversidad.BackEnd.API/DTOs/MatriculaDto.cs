using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class MatriculaDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Número Matricula")]
        public int NumeroMatricula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Número Ciclo")]
        public int NumeroCiclo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Cédula Estudiante")]
        public string CedulaEstudiante { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Monto Matrícula")]
        public decimal MontoMatricula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Monto Cursos")]
        public decimal? MontoCursos { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Monto Total")]
        public decimal? MontoTotal { get; set; }
    }
}
