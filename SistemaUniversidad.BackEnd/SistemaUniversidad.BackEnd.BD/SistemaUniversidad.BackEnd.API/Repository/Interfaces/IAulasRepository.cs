using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface IAulasRepository : IObtenerRepository<Aula, string>, IInsertarRepository<Aula>, IActualizarRepository<Aula>, IEliminarRepository<string>
    {
    }
}
