using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;


namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface ISedesRepository : IObtenerRepository<Sede, string>, IInsertarRepository<Sede>, IActualizarRepository<Sede>, IEliminarRepository<string>
    {
    }
}
