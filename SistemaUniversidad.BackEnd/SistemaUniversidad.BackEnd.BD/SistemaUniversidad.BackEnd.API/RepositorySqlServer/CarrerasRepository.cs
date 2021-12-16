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
    public class CarrerasRepository : ConexionBD, ICarrerasRepository
    {
        public CarrerasRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Carrera carreras)
        {

            var query = "SP_Carreras_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCarrera", carreras.CodigoCarrera);
            command.Parameters.AddWithValue("@NombreCarrera", carreras.NombreCarrera);
            command.Parameters.AddWithValue("@ModificadoPor", carreras.ModificadoPor);
            command.Parameters.AddWithValue("@Acreditada", carreras.Acreditada);
            command.Parameters.AddWithValue("@Activo", carreras.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Carrera carreras)
        {

            var query = "SP_Carreras_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCarrera", carreras.CodigoCarrera);
            command.Parameters.AddWithValue("@NombreCarrera", carreras.NombreCarrera);
            command.Parameters.AddWithValue("@CreadoPor", carreras.CreadoPor);

            command.ExecuteNonQuery();

        }


        public Carrera SeleccionarPorId(String CodigoCarrera)
        {
            var query = "SELECT * FROM vw_Carreras_SeleccionarActivos WHERE CodigoCarrera = @CodigoCarrera";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CodigoCarrera", CodigoCarrera);

            SqlDataReader reader = command.ExecuteReader();

            Carrera CarrerasSeleccionada = new();

            while (reader.Read())
            {
                CarrerasSeleccionada.CodigoCarrera = Convert.ToString(reader["CodigoCarrera"]);
                CarrerasSeleccionada.NombreCarrera = Convert.ToString(reader["NombreCarrera"]);
                CarrerasSeleccionada.Acreditada = Convert.ToBoolean(reader["Acreditada"]);
                CarrerasSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CarrerasSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CarrerasSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CarrerasSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CarrerasSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CarrerasSeleccionada;
        }

        public List<Carrera> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_Carreras_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Carrera> ListaTodasLasCarrera = new List<Carrera>();

            while (reader.Read())
            {
                Carrera CarrerasSeleccionada = new();

                CarrerasSeleccionada.CodigoCarrera = Convert.ToString(reader["CodigoCarrera"]);
                CarrerasSeleccionada.NombreCarrera = Convert.ToString(reader["NombreCarrera"]);
                CarrerasSeleccionada.Acreditada = Convert.ToBoolean(reader["Acreditada"]);
                CarrerasSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CarrerasSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CarrerasSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CarrerasSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CarrerasSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLasCarrera.Add(CarrerasSeleccionada);
            }

            reader.Close();

            return ListaTodasLasCarrera;
        }
    }
}
