using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface ICicloLectivoService
    {
        List<CicloLectivo> SeleccionarTodos();
        CicloLectivo SeleccionarPorId(string id);
        void Insertar(CicloLectivo model);
        void Actualizar(CicloLectivo model);
        void Eliminar(string id);

    }
}
