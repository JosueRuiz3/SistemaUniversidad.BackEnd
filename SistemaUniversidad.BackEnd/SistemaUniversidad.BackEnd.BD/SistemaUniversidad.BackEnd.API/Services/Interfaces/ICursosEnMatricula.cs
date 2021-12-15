using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface ICursosEnMatricula
    {
        List<CursosEnMatricula> SeleccionarTodos();
        CursosEnMatricula SeleccionarPorId(string id);
        void Insertar(CursosEnMatricula model);
        void Actualizar(CursosEnMatricula model);
        void Eliminar(string id);
    }
}
