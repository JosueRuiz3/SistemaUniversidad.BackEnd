using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface IEstudianteService
    {
        List<Estudiante> SeleccionarTodos();
        Estudiante SeleccionarPorId(string id);
        void Insertar(Estudiante model);
        void Actualizar(Estudiante model);
        void Eliminar(string id);

    }
}
