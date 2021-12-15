using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class SedeDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public string CodigoSede { get; set; } 

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreSede { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]

        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public string CreadoPor { get; set; }
    }
}
