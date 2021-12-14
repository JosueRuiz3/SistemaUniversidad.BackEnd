using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Dtos
{
    public class ProductoDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]
        [Display(Name = "Id Producto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Categoria { get; set; }
    }
}
