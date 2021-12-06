using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class VwMatriculasSeleccionarTodo
    {
        public int NumeroMatricula { get; set; }
        public int Ciclo { get; set; }
        public string CicloLectivo { get; set; }
        public DateTime InicoDelCiclo { get; set; }
        public DateTime FinDelCiclo { get; set; }
        public decimal MontoTotalMatricula { get; set; }
        public string CedulaDelEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaDeMatrCula { get; set; }
    }
}
