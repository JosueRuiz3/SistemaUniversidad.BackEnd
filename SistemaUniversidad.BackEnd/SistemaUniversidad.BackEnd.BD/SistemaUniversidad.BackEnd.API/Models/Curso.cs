using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class Curso
    {
        public Curso()
        {
            CursosConProfesores = new HashSet<CursosConProfesore>();
            CursosEnAulas = new HashSet<CursosEnAula>();
            CursosEnMatriculas = new HashSet<CursosEnMatricula>();
        }


        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreCurso { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public decimal? Precio { get; set; }

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
    }
}
