using SistemaUniversidad.BackEnd.API.Models;
using SistemaUniversidad.BackEnd.API.Repository.Interfaces;
using SistemaUniversidad.BackEnd.API.RepositorySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Repository
{
    public class CicloLectivoRepository : ConexionBD, ICiclosLectivosRepository
    {
        public CicloLectivoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(CicloLectivo ciclolectivo)
        {

            var query = "SP_CiclosLectivos_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroCiclo", ciclolectivo.NumeroCiclo);
            command.Parameters.AddWithValue("@NombreCiclo", ciclolectivo.NombreCiclo);
            command.Parameters.AddWithValue("@FechaInicio", ciclolectivo.FechaInicio);
            command.Parameters.AddWithValue("@FechaFin", ciclolectivo.FechaFin);
            command.Parameters.AddWithValue("@ModificadoPor", ciclolectivo.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", ciclolectivo.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(CicloLectivo ciclolectivo)
        {

            var query = "SP_CiclosLectivos_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroCiclo", ciclolectivo.NumeroCiclo);
            command.Parameters.AddWithValue("@NombreCiclo", ciclolectivo.NombreCiclo);
            command.Parameters.AddWithValue("@FechaInicio", ciclolectivo.FechaInicio);
            command.Parameters.AddWithValue("@FechaFin", ciclolectivo.FechaFin);
            command.Parameters.AddWithValue("@CreadoPor", ciclolectivo.CreadoPor);

            command.ExecuteNonQuery();

        }

        public CicloLectivo SeleccionarPorId(String NumeroCiclo)
        {
            var query = "SELECT * FROM vw_CicloLectivos_SeleccionarActivos WHERE NumeroCiclo = @NumeroCiclo";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NumeroCiclo", NumeroCiclo);

            SqlDataReader reader = command.ExecuteReader();

            CicloLectivo CicloLectivoSeleccionada = new();

            while (reader.Read())
            {
                CicloLectivoSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroAula"]);
                CicloLectivoSeleccionada.NombreCiclo = Convert.ToString(reader["NombreCiclo"]);
                CicloLectivoSeleccionada.FechaInicio = Convert.ToDateTime(reader["NombreCiclo"]);
                CicloLectivoSeleccionada.FechaFin = Convert.ToDateTime(reader["NombreCiclo"]);
                CicloLectivoSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CicloLectivoSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CicloLectivoSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CicloLectivoSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CicloLectivoSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CicloLectivoSeleccionada;
        }

        public List<CicloLectivo> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_CicloLectivos_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<CicloLectivo> ListaTodoLosCiclosLectivos = new List<CicloLectivo>();

            while (reader.Read())
            {
                CicloLectivo CicloLectivoSeleccionada = new();

                CicloLectivoSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroAula"]);
                CicloLectivoSeleccionada.NombreCiclo = Convert.ToString(reader["NombreCiclo"]);
                CicloLectivoSeleccionada.FechaInicio = Convert.ToDateTime(reader["NombreCiclo"]);
                CicloLectivoSeleccionada.FechaFin = Convert.ToDateTime(reader["NombreCiclo"]);
                CicloLectivoSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CicloLectivoSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CicloLectivoSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CicloLectivoSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CicloLectivoSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodoLosCiclosLectivos.Add(CicloLectivoSeleccionada);
            }

            reader.Close();

            return ListaTodoLosCiclosLectivos;
        }
    }
}
