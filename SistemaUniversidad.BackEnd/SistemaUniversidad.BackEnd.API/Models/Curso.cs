using System;
using System.Collections.Generic;

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

        public string CodigoCurso { get; set; }
        public string NombreCurso { get; set; }
        public decimal? Precio { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

        public virtual ICollection<CursosConProfesore> CursosConProfesores { get; set; }
        public virtual ICollection<CursosEnAula> CursosEnAulas { get; set; }
        public virtual ICollection<CursosEnMatricula> CursosEnMatriculas { get; set; }
    }
}
