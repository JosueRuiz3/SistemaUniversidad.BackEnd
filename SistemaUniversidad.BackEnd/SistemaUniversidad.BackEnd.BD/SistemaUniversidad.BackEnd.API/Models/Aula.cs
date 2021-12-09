﻿using System;

namespace SistemaUniversidad.BackEnd.API.Models
{
    public class Aula
	{
		public string NumeroAula { get; set; }

		public string NombreAula { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

	}
}
