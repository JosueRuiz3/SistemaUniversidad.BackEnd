using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
    public interface IAulasService
    {
        List<Aula> SeleccionarTodos();
        Aula SeleccionarPorId(string id);
        void Insertar(Aula model);
        void Actualizar(Aula model);
        void Eliminar(int id);
    }
}
