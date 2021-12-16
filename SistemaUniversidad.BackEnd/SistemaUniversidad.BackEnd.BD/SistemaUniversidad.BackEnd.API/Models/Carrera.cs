using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class Carrera
    {
        public string CodigoCarrera { get; set; }

        public string NombreCarrera { get; set; }

        public bool? Acreditada { get; set; }

        public bool? Activo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}
