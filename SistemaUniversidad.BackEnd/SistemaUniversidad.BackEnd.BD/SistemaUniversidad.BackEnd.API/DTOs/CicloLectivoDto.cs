using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class CicloLectivoDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Número Ciclo")]
        public int NumeroCiclo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Nombre Ciclo")]
        public string NombreCiclo { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha  de fin es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }
    }
}
