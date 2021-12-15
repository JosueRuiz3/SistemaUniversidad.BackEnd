using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface IProfesoresService
    {
        List<Profesore> SeleccionarTodos();
        Profesore SeleccionarPorId(string id);
        void Insertar(Profesore model);
        void Actualizar(Profesore model);
        void Eliminar(string id);
    }
}
