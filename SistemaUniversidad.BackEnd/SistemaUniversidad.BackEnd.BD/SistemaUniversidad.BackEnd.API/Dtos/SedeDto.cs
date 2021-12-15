using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.DTOs
{
    public class SedeDto
    {

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public int CodigoSede { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreSede { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CreadoPor { get; set; }
    }
}
