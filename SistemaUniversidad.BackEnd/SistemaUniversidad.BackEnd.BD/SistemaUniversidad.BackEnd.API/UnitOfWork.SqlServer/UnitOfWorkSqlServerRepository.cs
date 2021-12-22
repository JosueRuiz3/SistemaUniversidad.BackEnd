using SistemaUniversidad.BackEnd.API.Repository.Interfaces;
using SistemaUniversidad.BackEnd.API.Repository;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

using System.Data.SqlClient;
using SistemaUniversidad.BackEnd.API.RepositorySqlServer;

namespace SistemaUniversidad.BackEnd.API.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IAulasRepository AulaRepository { get; }

        public ISedesRepository SedeRepository { get; }

        public ICarrerasRepository CarrerasRepository { get; }

        public ICiclosLectivosRepository CicloLectivoRepository { get; }

        public ICursosRepository CursosRepository { get; }

        public ICursosConProfesoresRepository CursosConProfesoresRepository { get; }

        public ICursosEnAulasRepository CursosEnAulasRepository { get; }

        public ICursosEnMatriculasRepository CursosEnMatriculasRepository { get; }

        public IMatriculasRepository MatriculasRepository { get; }

        public IEstudiantesRepository EstudiantesRepository { get; }

        public IProfesoresRepository ProfesoresRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            AulaRepository = new AulasRepository(context, transaction);

            SedeRepository = new SedeRepository(context, transaction);

            CarrerasRepository = new CarrerasRepository(context, transaction);

            CicloLectivoRepository = new CicloLectivoRepository(context, transaction);

            CursosRepository = new CursosRepository(context, transaction);

            CursosConProfesoresRepository = new CursosConProfesoresRepository(context, transaction);

            CursosEnAulasRepository = new CursosEnAulaRepository(context, transaction);

            CursosEnMatriculasRepository = new CursosEnMatriculaRepository(context, transaction);

            MatriculasRepository = new MatriculaRepository(context, transaction);

            EstudiantesRepository = new EstudianteRepository(context, transaction);

            ProfesoresRepository = new ProfesoresRepository(context, transaction);

        }

    }
}
