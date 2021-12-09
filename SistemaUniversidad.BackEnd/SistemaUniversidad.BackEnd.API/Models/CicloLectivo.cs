using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class CicloLectivo
    {
        public CicloLectivo()
        {
            CursosConProfesores = new HashSet<CursosConProfesore>();
            CursosEnAulas = new HashSet<CursosEnAula>();
            CursosEnMatriculas = new HashSet<CursosEnMatricula>();
            Matriculas = new HashSet<Matricula>();
        }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(4, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public int NumeroCiclo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreCiclo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public DateTime FechaFin { get; set; }

        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CreadoPor { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string ModificadoPor { get; set; }

        public virtual ICollection<CursosConProfesore> CursosConProfesores { get; set; }
        public virtual ICollection<CursosEnAula> CursosEnAulas { get; set; }
        public virtual ICollection<CursosEnMatricula> CursosEnMatriculas { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
