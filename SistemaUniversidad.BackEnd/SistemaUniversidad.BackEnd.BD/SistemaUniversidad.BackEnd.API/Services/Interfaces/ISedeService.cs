using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
    public interface ISedeService
    {
        IEnumerable<Sede> SeleccionarTodos();
        void Insertar(Sede model);
        void Actualizar(Sede model);
        void Eliminar(int id);
        Sede SeleccionarPorId(string id);
    }
}
