using SistemaUniversidad.BackEnd.API.Models;
using SistemaUniversidad.BackEnd.API.Repository.Interfaces;
using SistemaUniversidad.BackEnd.API.Repository.Interfaces.Actions;
using SistemaUniversidad.BackEnd.API.RepositorySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Repository
{
    public class CarreraRepository : ConexionBD, ICarrerasRepository
    {
        public CarreraRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Actualizar(Carrera carrera)
        {

            var query = "SP_Carreras_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCarrera", carrera.CodigoCarrera);
            command.Parameters.AddWithValue("@NombreCarrera", carrera.NombreCarrera);
            command.Parameters.AddWithValue("@Activo", carrera.Activo);

            command.ExecuteNonQuery();
        }



        public void Insertar(Carrera carrera)
        {
            var query = "SP_Carreras_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCarrera", carrera.CodigoCarrera);
            command.Parameters.AddWithValue("@NombreCarrera", carrera.NombreCarrera);
            command.Parameters.AddWithValue("@CreadoPor", carrera.CreadoPor);

            command.ExecuteNonQuery();
        }

   

        public Carrera SeleccionarPorId(int CodigoCarrera)
        {
            var query = "SELECT * FROM vw_Carreras_SeleccionarActivos WHERE CodigoCarrera = @CodigoCarrera";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CodigoCarrera", CodigoCarrera);

            SqlDataReader reader = command.ExecuteReader();

            Carrera CarreraSeleccionada = new();

            while (reader.Read())
            {
                CarreraSeleccionada.CodigoCarrera = Convert.ToString(reader["CodigoCarrera"]);
                CarreraSeleccionada.NombreCarrera = Convert.ToString(reader["NombreCarrera"]);
                CarreraSeleccionada.Acreditada = Convert.ToBoolean(reader["Acreditada"]);
                CarreraSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CarreraSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CarreraSeleccionada.FechaModificacion = (DateTime)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CarreraSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CarreraSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);
            }

            reader.Close();

            return CarreraSeleccionada;
        }

        public List<Carrera> SeleccionarTodos()
        {
            var query = "SELECT * FROM vw_Carreras_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Carrera> ListaTodasLasCarreras = new List<Carrera>();

            while (reader.Read())
            {
                Carrera CarreraSeleccionada = new();

                CarreraSeleccionada.CodigoCarrera = Convert.ToString(reader["CodigoCarrera"]);
                CarreraSeleccionada.NombreCarrera = Convert.ToString(reader["NombreCarrera"]);
                CarreraSeleccionada.Acreditada = Convert.ToBoolean(reader["Acreditada"]);
                CarreraSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CarreraSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CarreraSeleccionada.FechaModificacion = (DateTime)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CarreraSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CarreraSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLasCarreras.Add(CarreraSeleccionada);
            }

            reader.Close();

            return ListaTodasLasCarreras;
        }

    }
}
