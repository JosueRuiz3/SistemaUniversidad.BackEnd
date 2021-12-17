
using SistemaUniversidad.BackEnd.API.Repository.Interfaces;

namespace SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IAulasRepository AulaRepository { get; }

        ISedesRepository SedeRepository { get; }

        ICarrerasRepository CarrerasRepository { get; }

        ICiclosLectivosRepository CicloLectivoRepository { get; }
    }
}
