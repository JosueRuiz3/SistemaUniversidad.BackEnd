﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class EstudianteDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Cédula Estudiante")]
        public string CedulaEstudiante { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public int Edad { get; set; }
    }
}
