using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface IMatriculaServices
    {
        List<Matricula> SeleccionarTodos();
        Matricula SeleccionarPorId(string id);
        void Insertar(Matricula model);
        void Actualizar(Matricula model);
        void Eliminar(string id);
    }
}
