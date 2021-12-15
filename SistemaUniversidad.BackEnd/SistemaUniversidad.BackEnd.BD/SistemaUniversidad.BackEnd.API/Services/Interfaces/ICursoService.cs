using SistemaUniversidad.BackEnd.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
    public interface ICursoService
    {
        List<Curso> SeleccionarTodos();
        Curso SeleccionarPorId(string id);
        void Insertar(Curso model);
        void Actualizar(Curso model);
        void Eliminar(string id);

    }
}
