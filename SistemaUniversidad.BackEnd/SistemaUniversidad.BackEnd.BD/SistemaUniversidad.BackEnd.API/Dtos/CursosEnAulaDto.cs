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
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NumeroAula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NumeroCiclo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string HorarioInicio { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string HorarioFin { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string DiaDeLaSemana { get; set; }
        public bool? Activo { get; set; }
    }
}
