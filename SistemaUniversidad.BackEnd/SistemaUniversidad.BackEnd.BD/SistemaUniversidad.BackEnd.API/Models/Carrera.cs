using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class Carrera
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public int CodigoCarrera { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreCarrera { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public bool? Acreditada { get; set; }

        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CreadoPor { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string ModificadoPor { get; set; }
    }
}
