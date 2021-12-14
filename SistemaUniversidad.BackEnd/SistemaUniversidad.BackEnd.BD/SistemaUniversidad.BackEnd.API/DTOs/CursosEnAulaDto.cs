using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class CursosEnAulaDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Código Curso")]
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Número Aula")]
        public string NumeroAula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Número Ciclo")]
        public int NumeroCiclo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Horario Inicio")]
        public string HorarioInicio { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Horario Fin")]
        public string HorarioFin { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Día De La Semana")]
        public string DiaDeLaSemana { get; set; }
    }
}
