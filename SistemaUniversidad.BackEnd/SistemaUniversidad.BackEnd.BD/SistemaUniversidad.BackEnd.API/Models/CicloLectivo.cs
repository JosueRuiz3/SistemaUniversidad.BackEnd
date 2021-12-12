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

        public int NumeroCiclo { get; set; }
        public string NombreCiclo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

        public virtual ICollection<CursosConProfesore> CursosConProfesores { get; set; }
        public virtual ICollection<CursosEnAula> CursosEnAulas { get; set; }
        public virtual ICollection<CursosEnMatricula> CursosEnMatriculas { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
