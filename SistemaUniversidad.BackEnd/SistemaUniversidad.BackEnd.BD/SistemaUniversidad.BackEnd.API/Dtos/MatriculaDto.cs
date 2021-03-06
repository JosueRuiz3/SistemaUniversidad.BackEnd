using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class MatriculaDto
    {
        public int NumeroMatricula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NumeroCiclo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CedulaEstudiante { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public decimal MontoMatricula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public decimal? MontoCursos { get; set; }

        public decimal? MontoTotal { get; set; }
        public bool? Activo { get; set; }
    }
}
