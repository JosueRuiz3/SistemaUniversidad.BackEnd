using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface ICiclosLectivosRepository : IObtenerRepository<CicloLectivo, string>, IInsertarRepository<CicloLectivo>, IActualizarRepository<CicloLectivo>, IEliminarRepository<int>
    {
    }
}
