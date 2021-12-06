using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class VwCursosConProfesoresSeleccionarActivo
    {
        public string CodigoCurso { get; set; }
        public string CedulaProfesor { get; set; }
        public int NumeroCiclo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}
