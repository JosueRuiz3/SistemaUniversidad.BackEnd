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
    public class EstudianteRepository : ConexionBD, IEstudiantesRepository
    {
        public EstudianteRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Estudiante estudiante)
        {

            var query = "SP_Estudiantes_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaEstudiante", estudiante.CedulaEstudiante);
            command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            command.Parameters.AddWithValue("@Apellidos", estudiante.Apellidos);
            command.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
            command.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
            command.Parameters.AddWithValue("@CorreoElectronico", estudiante.CorreoElectronico);
            command.Parameters.AddWithValue("@Edad", estudiante.Edad);
            command.Parameters.AddWithValue("@ModificadoPor", estudiante.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", estudiante.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Estudiante estudiante)
        {
            
            var query = "SP_Estudiantes_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaEstudiante", estudiante.CedulaEstudiante);
            command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            command.Parameters.AddWithValue("@Apellidos", estudiante.Apellidos);
            command.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
            command.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
            command.Parameters.AddWithValue("@CorreoElectronico", estudiante.CorreoElectronico);
            command.Parameters.AddWithValue("@Edad", estudiante.Edad);
            command.Parameters.AddWithValue("@CreadoPor", estudiante.CreadoPor);

            command.ExecuteNonQuery();

        }

        public Estudiante SeleccionarPorId(String CedulaEstudiante)
        {
            var query = "SELECT * FROM vw_Estudiantes_SeleccionarActivos WHERE CedulaEstudiante = @CedulaEstudiante";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CedulaEstudiante", CedulaEstudiante);

            SqlDataReader reader = command.ExecuteReader();

            Estudiante EstudianteSeleccionada = new();

            while (reader.Read())
            {
                EstudianteSeleccionada.CedulaEstudiante = Convert.ToString(reader["CedulaEstudiante"]);
                EstudianteSeleccionada.Nombre = Convert.ToString(reader["Nombre"]);
                EstudianteSeleccionada.Apellidos = Convert.ToString(reader["Apellidos"]);
                EstudianteSeleccionada.Telefono = Convert.ToString(reader["Telefono"]);
                EstudianteSeleccionada.Direccion = Convert.ToString(reader["Direccion"]);
                EstudianteSeleccionada.CorreoElectronico = Convert.ToString(reader["CorreoElectronico"]);
                EstudianteSeleccionada.Edad = Convert.ToInt32(reader["Edad"]);
                EstudianteSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                EstudianteSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                EstudianteSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                EstudianteSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                EstudianteSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return EstudianteSeleccionada;
        }

        public List<Estudiante> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_Estudiantes_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Estudiante> ListaTodasLosEstudiante = new List<Estudiante>();

            while (reader.Read())
            {
                Estudiante EstudianteSeleccionada = new();

                EstudianteSeleccionada.CedulaEstudiante = Convert.ToString(reader["CedulaEstudiante"]);
                EstudianteSeleccionada.Nombre = Convert.ToString(reader["Nombre"]);
                EstudianteSeleccionada.Apellidos = Convert.ToString(reader["Apellidos"]);
                EstudianteSeleccionada.Telefono = Convert.ToString(reader["Telefono"]);
                EstudianteSeleccionada.Direccion = Convert.ToString(reader["Direccion"]);
                EstudianteSeleccionada.CorreoElectronico = Convert.ToString(reader["CorreoElectronico"]);
                EstudianteSeleccionada.Edad = Convert.ToInt32(reader["Edad"]);
                EstudianteSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                EstudianteSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                EstudianteSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                EstudianteSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                EstudianteSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLosEstudiante.Add(EstudianteSeleccionada);
            }

            reader.Close();

            return ListaTodasLosEstudiante;
        }
    }
}
