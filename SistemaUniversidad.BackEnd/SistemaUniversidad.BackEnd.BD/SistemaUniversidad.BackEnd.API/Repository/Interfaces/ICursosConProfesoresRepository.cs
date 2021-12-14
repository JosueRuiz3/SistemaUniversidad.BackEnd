using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
    public interface ICursosConProfesoresRepository : IObtenerRepository<CursosConProfesore, string>, IInsertarRepository<CursosConProfesore>, IActualizarRepository<CursosConProfesore>, IEliminarRepository<int>
    {
    }
}
