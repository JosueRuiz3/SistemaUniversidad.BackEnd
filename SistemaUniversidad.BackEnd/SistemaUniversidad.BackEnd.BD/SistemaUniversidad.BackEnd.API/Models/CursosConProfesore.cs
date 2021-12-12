using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class CursosConProfesore
    {
        public string CodigoCurso { get; set; }
        public string CedulaProfesor { get; set; }
        public int NumeroCiclo { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

        public virtual Profesore CedulaProfesorNavigation { get; set; }
        public virtual Curso CodigoCursoNavigation { get; set; }
        public virtual CicloLectivo NumeroCicloNavigation { get; set; }
    }
}
