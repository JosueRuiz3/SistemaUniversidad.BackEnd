﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class CarreraDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Codigo Carrera")]
        public int CodigoCarrera { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Nombre Carrera")]
        public string NombreCarrera { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public bool? Acreditada { get; set; }
    }
}
