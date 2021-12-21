using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface IMatriculasRepository : IObtenerRepository<Matricula, string>, IInsertarRepository<Matricula>, IActualizarRepository<Matricula>, IEliminarRepository<string>
    {
    }
}
