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
        public void Actualizar(CicloLectivo cicloLectivo)
        {

            var query = "SP_CiclosLectivos_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroCiclo", cicloLectivo.NumeroCiclo);
            command.Parameters.AddWithValue("@NombreCiclo", cicloLectivo.NombreCiclo);
            command.Parameters.AddWithValue("@FechaInicio", cicloLectivo.FechaInicio);
            command.Parameters.AddWithValue("@FechaFin", cicloLectivo.FechaFin);
            command.Parameters.AddWithValue("@ModificadoPor", cicloLectivo.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", cicloLectivo.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(CicloLectivo cicloLectivo)
        {

            var query = "SP_CiclosLectivos_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroCiclo", cicloLectivo.NumeroCiclo);
            command.Parameters.AddWithValue("@NombreCiclo", cicloLectivo.NombreCiclo);
            command.Parameters.AddWithValue("@FechaInicio", cicloLectivo.FechaInicio);
            command.Parameters.AddWithValue("@FechaFin", cicloLectivo.FechaFin);
            command.Parameters.AddWithValue("@CreadoPor", cicloLectivo.CreadoPor);

            command.ExecuteNonQuery();

        }

        public CicloLectivo SeleccionarPorId(String NumeroCiclo)
        {
            var query = "SELECT * FROM vw_CicloLectivos_SeleccionarActivos WHERE NumeroCiclo = @NumeroCiclo";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NumeroCiclo", NumeroCiclo);

            SqlDataReader reader = command.ExecuteReader();

            CicloLectivo CicloLectivoSeleccionado = new();

            while (reader.Read())
            {
                CicloLectivoSeleccionado.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CicloLectivoSeleccionado.NombreCiclo = Convert.ToString(reader["NombreCiclo"]);
                CicloLectivoSeleccionado.FechaInicio = Convert.ToDateTime(reader["FechaInicio"]);
                CicloLectivoSeleccionado.FechaFin = Convert.ToDateTime(reader["FechaFin"]);
                CicloLectivoSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                CicloLectivoSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CicloLectivoSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CicloLectivoSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CicloLectivoSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CicloLectivoSeleccionado;
        }

        public List<CicloLectivo> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_CicloLectivos_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<CicloLectivo> ListaTodosLosCicloLectivos = new List<CicloLectivo>();

            while (reader.Read())
            {
                CicloLectivo CicloLectivoSeleccionado = new();

                CicloLectivoSeleccionado.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CicloLectivoSeleccionado.NombreCiclo = Convert.ToString(reader["NombreCiclo"]);
                CicloLectivoSeleccionado.FechaInicio = Convert.ToDateTime(reader["FechaInicio"]);
                CicloLectivoSeleccionado.FechaFin = Convert.ToDateTime(reader["FechaFin"]);
                CicloLectivoSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                CicloLectivoSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CicloLectivoSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CicloLectivoSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CicloLectivoSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodosLosCicloLectivos.Add(CicloLectivoSeleccionado);
            }

            reader.Close();

            return ListaTodosLosCicloLectivos;
        }
    }
}
