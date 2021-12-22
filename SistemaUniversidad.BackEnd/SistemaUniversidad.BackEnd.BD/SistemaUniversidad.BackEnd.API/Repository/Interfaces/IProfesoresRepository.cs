using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface IProfesoresRepository : IObtenerRepository<Profesore, string>, IInsertarRepository<Profesore>, IActualizarRepository<Profesore>, IEliminarRepository<string>
    {
    }
}
