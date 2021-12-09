//using Common;
using Microsoft.Extensions.Configuration;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkSqlServer(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Conectar()
        {            
            var connectionString = _configuration.GetConnectionString("Conexion");

            return new UnitOfWorkSqlServerAdapter(connectionString);
        }
    }
}
