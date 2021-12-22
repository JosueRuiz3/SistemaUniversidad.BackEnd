﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.FrontEnd.Pr0.Dtos
{
    public class AulaDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        public string NumeroAula { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreAula { get; set; }

        public bool Activo { get; set; }
    }
}
