using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface ICursosEnAulasRepository : IObtenerRepository<CursosEnAula, string>, IInsertarRepository<CursosEnAula>, IActualizarRepository<CursosEnAula>, IEliminarRepository<int>
    {
    }
}
