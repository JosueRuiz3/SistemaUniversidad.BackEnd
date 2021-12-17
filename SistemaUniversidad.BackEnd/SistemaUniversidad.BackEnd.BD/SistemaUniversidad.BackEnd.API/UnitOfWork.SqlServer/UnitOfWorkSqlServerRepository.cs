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
        //Acá van todos los otros repositorios
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            AulaRepository = new AulasRepository(context, transaction);

            SedeRepository = new SedeRepository(context, transaction);

            CarrerasRepository = new CarrerasRepository(context, transaction);

            CicloLectivoRepository = new CicloLectivoRepository(context, transaction);

            CursosRepository = new CursosRepository(context, transaction);

            CursosConProfesoresRepository = new CursosConProfesoresRepository(context, transaction);
            //Acá van todos los otros repositorios

        }

    }
}
