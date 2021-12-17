using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class CursosEnAula
    {
        public string CodigoCurso { get; set; }
        public string NumeroAula { get; set; }
        public int NumeroCiclo { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFin { get; set; }
        public string DiaDeLaSemana { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

        public virtual Curso CodigoCursoNavigation { get; set; }
        //public virtual Aula NumeroAulaNavigation { get; set; }
        //public virtual CicloLectivo NumeroCicloNavigation { get; set; }
    }
}
