using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaUniversidad.BackEnd.API.Models
{
    public class Aula
	{

		public Aula()
		{
			CursosEnAulas = new HashSet<CursosEnAula>(); 
		}
		public string NumeroAula { get; set; }

		public string NombreAula { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

		public virtual ICollection<CursosEnAula> CursosEnAulas { get; set; }

	}
}
