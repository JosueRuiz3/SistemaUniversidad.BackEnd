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
    public class SedeRepository : ConexionBD, ISedesRepository
    {
        public SedeRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Actualizar(Sede sede)
        {

            var query = "SP_Sedes_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoSede", sede.CodigoSede);
            command.Parameters.AddWithValue("@NombreSede", sede.NombreSede);
            command.Parameters.AddWithValue("@Telefono", sede.Telefono);
            command.Parameters.AddWithValue("@CorreoElectronico", sede.CorreoElectronico);
            command.Parameters.AddWithValue("@Direccion", sede.Direccion);
            command.Parameters.AddWithValue("@ModificadoPor", sede.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", sede.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Sede sede)
        {
            var query = "SP_Sedes_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoSede", sede.CodigoSede);
            command.Parameters.AddWithValue("@NombreSede", sede.NombreSede);
            command.Parameters.AddWithValue("@Telefono", sede.Telefono);
            command.Parameters.AddWithValue("@CorreoElectronico", sede.CorreoElectronico);
            command.Parameters.AddWithValue("@Direccion", sede.Direccion);
            command.Parameters.AddWithValue("@CreadoPor", sede.CreadoPor);

            command.ExecuteNonQuery();
        }

        public Sede SeleccionarPorId(string CodigoSede)
        {
            var query = "SELECT * FROM vw_Sedes_SeleccionarActivos WHERE CodigoSede = @CodigoSede";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CodigoSede", CodigoSede);

            SqlDataReader reader = command.ExecuteReader();

            Sede SedeSeleccionada = new();

            while (reader.Read())
            {
                SedeSeleccionada.CodigoSede = Convert.ToString(reader["CodigoSede"]);
                SedeSeleccionada.NombreSede = Convert.ToString(reader["NombreSede"]);
                SedeSeleccionada.Telefono = Convert.ToString(reader["v"]);
                SedeSeleccionada.CorreoElectronico = Convert.ToString(reader["CorreoElectronico"]);
                SedeSeleccionada.Direccion = Convert.ToString(reader["Direccion"]);
                SedeSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                SedeSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                SedeSeleccionada.FechaModificacion = (DateTime)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                SedeSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                SedeSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);
            }

            reader.Close();

            return SedeSeleccionada;
        }

        public List<Sede> SeleccionarTodos()
        {
            var query = "SELECT * FROM vw_Sedes_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Sede> ListaTodasLasSedes = new List<Sede>();

            while (reader.Read())
            {
                Sede SedeSeleccionada = new();

                SedeSeleccionada.CodigoSede = Convert.ToString(reader["CodigoSede"]);
                SedeSeleccionada.NombreSede = Convert.ToString(reader["NombreSede"]);
                SedeSeleccionada.Telefono = Convert.ToString(reader["Telefono"]);
                SedeSeleccionada.CorreoElectronico = Convert.ToString(reader["CorreoElectronico"]);
                SedeSeleccionada.Direccion = Convert.ToString(reader["Direccion"]);
                SedeSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                SedeSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                SedeSeleccionada.FechaModificacion = (DateTime)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                SedeSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                SedeSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLasSedes.Add(SedeSeleccionada);
            }

            reader.Close();

            return ListaTodasLasSedes;
        }
    }
}
