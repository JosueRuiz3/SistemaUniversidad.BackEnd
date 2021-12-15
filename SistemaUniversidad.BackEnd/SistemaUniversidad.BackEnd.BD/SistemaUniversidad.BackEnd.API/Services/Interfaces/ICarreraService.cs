using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface ICarreraService
    {
        IEnumerable<Carrera> SeleccionarTodos();
        Carrera SeleccionarPorId(string id);
        void Insertar(Carrera model);
        void Actualizar(Carrera model);
        void Eliminar(int id);


    }
}
