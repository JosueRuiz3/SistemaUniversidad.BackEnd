using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface IEstudiantesRepository : IObtenerRepository<Estudiante, string>, IInsertarRepository<Estudiante>, IActualizarRepository<Estudiante>, IEliminarRepository<string>
    {
    }
}
