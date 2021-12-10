using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;


namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface ISedesRepository : IObtenerRepository<Sede, int>, IInsertarRepository<Sede>, IActualizarRepository<Sede>, IEliminarRepository<int>
    {
    }
}
