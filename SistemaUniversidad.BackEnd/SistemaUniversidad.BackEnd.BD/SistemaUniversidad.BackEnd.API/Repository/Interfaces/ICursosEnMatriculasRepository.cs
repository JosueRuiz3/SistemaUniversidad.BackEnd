using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface ICursosEnMatriculasRepository : IObtenerRepository<CursosEnMatricula, string>, IInsertarRepository<CursosEnMatricula>, IActualizarRepository<CursosEnMatricula>, IEliminarRepository<int>
    {
    }
}
