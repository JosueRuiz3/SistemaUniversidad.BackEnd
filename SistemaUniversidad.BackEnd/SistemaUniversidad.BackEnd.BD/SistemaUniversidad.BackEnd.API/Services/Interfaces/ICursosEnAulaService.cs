using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface ICursosEnAulaService
    {
        List<CursosEnAula> SeleccionarTodos();
        CursosEnAula SeleccionarPorId(string id);
        void Insertar(CursosEnAula model);
        void Actualizar(CursosEnAula model);
        void Eliminar(string id);
    }
}
