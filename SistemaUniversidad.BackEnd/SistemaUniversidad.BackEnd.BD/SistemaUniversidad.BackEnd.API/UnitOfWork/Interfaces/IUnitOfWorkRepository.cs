
using SistemaUniversidad.BackEnd.API.Repository.Interfaces;

namespace SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IAulasRepository AulaRepository { get; }

        ISedesRepository SedeRepository { get; }

        ICarrerasRepository CarrerasRepository { get; }

        ICiclosLectivosRepository CicloLectivoRepository { get; }

        ICursosRepository CursosRepository { get; }

        ICursosConProfesoresRepository CursosConProfesoresRepository { get; }

        ICursosEnAulasRepository CursosEnAulasRepository { get; }

        ICursosEnMatriculasRepository CursosEnMatriculasRepository { get; }

        IMatriculasRepository MatriculasRepository { get; }

        IEstudiantesRepository EstudiantesRepository { get; }
    }
}
