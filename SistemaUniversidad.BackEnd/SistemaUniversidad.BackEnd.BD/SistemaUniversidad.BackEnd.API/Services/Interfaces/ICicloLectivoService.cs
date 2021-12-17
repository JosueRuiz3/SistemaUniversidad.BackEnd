using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.Models;

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
