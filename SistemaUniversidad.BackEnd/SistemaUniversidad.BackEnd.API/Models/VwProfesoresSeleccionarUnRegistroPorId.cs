using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class VwProfesoresSeleccionarUnRegistroPorId
    {
        public string CedulaProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Profesion { get; set; }
        public string CorreoElectronico { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}
