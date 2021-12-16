using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
   public interface ICursosConProfesoreService
    {
        List<CursosConProfesore> SeleccionarTodos();
        CursosConProfesore SeleccionarPorId(string id);
        void Insertar(CursosConProfesore model);
        void Actualizar(CursosConProfesore model);
        void Eliminar(string id);
    }
}
