using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class CursosConProfesoreDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CedulaProfesor { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NumeroCiclo { get; set; }

        public bool? Activo { get; set; }
    }
}
