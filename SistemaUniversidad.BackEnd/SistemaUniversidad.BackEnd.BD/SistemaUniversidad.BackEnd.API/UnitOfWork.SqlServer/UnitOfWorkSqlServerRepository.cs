
using SistemaUniversidad.BackEnd.API.Repository.Interfaces;
using SistemaUniversidad.BackEnd.API.Repository;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

using System.Data.SqlClient;

namespace SistemaUniversidad.BackEnd.API.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IAulasRepository AulaRepository { get; }
        //Acá van todos los otros repositorios
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            AulaRepository = new AulasRepository(context, transaction);
            //Acá van todos los otros repositorios

        }

    }
}
