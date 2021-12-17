using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface ICursosRepository : IObtenerRepository<Curso, string>, IInsertarRepository<Curso>, IActualizarRepository<Curso>, IEliminarRepository<string>
    {
    }
}
