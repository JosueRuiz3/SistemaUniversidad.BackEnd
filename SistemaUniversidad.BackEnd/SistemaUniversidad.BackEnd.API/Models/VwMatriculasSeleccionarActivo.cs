using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class VwMatriculasSeleccionarActivo
    {
        public int NumeroMatricula { get; set; }
        public int NumeroCiclo { get; set; }
        public string CedulaEstudiante { get; set; }
        public decimal MontoMatricula { get; set; }
        public decimal? MontoCursos { get; set; }
        public decimal? MontoTotal { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}
