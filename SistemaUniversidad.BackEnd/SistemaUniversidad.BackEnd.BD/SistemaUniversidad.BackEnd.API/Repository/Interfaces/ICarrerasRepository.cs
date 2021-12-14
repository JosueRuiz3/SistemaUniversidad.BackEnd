using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Repository.Interfaces
{
	public interface ICarrerasRepository : IObtenerRepository<Carrera, string>, IInsertarRepository<Carrera>, IActualizarRepository<Carrera>, IEliminarRepository<int>
	{
	}
}
