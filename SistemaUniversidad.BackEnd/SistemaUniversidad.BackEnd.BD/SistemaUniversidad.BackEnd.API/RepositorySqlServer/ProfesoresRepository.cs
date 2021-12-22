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

namespace SistemaUniversidad.BackEnd.API.RepositorySqlServer
{
    public class ProfesoresRepository : ConexionBD, IProfesoresRepository
    {
        public ProfesoresRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Profesore profesore)
        {

            var query = "SP_Profesores_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaProfesor", profesore.CedulaProfesor);
            command.Parameters.AddWithValue("@NombreProfesor", profesore.NombreProfesor);
            command.Parameters.AddWithValue("@Apellidos", profesore.Apellidos);
            command.Parameters.AddWithValue("@Telefono", profesore.Telefono);
            command.Parameters.AddWithValue("@Profesion", profesore.Profesion);
            command.Parameters.AddWithValue("@CorreoElectronico", profesore.CorreoElectronico);
            command.Parameters.AddWithValue("@Edad", profesore.Edad);
            command.Parameters.AddWithValue("@ModificadoPor", profesore.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", profesore.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Profesore profesore)
        {

            var query = "SP_Profesores_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaProfesor", profesore.CedulaProfesor);
            command.Parameters.AddWithValue("@NombreProfesor", profesore.NombreProfesor);
            command.Parameters.AddWithValue("@Apellidos", profesore.Apellidos);
            command.Parameters.AddWithValue("@Telefono", profesore.Telefono);
            command.Parameters.AddWithValue("@Profesion", profesore.Profesion);
            command.Parameters.AddWithValue("@CorreoElectronico", profesore.CorreoElectronico);
            command.Parameters.AddWithValue("@Edad", profesore.Edad);
            command.Parameters.AddWithValue("@CreadoPor", profesore.CreadoPor);

            command.ExecuteNonQuery();

        } 

        public Profesore SeleccionarPorId(String CedulaProfesor)
        {
            var query = "SELECT * FROM vw_Profesores_SeleccionarActivos WHERE CedulaProfesor = @CedulaProfesor";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CedulaProfesor", CedulaProfesor);

            SqlDataReader reader = command.ExecuteReader();

            Profesore ProfesorSeleccionado = new();

            while (reader.Read())
            {
                ProfesorSeleccionado.CedulaProfesor = Convert.ToString(reader["CedulaProfesor"]);
                ProfesorSeleccionado.NombreProfesor = Convert.ToString(reader["NombreProfesor"]);
                ProfesorSeleccionado.Apellidos = Convert.ToString(reader["Apellidos"]);
                ProfesorSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                ProfesorSeleccionado.Profesion = Convert.ToString(reader["Profesion"]);
                ProfesorSeleccionado.CorreoElectronico = Convert.ToString(reader["CorreoElectronico"]);
                ProfesorSeleccionado.Edad = Convert.ToInt32(reader["Edad"]);
                ProfesorSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                ProfesorSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                ProfesorSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                ProfesorSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                ProfesorSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return ProfesorSeleccionado;
        }

        public List<Profesore> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_Profesores_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Profesore> ListaTodosLosProfesores = new List<Profesore>();

            while (reader.Read())
            {
                Profesore ProfesorSeleccionado = new();

                ProfesorSeleccionado.CedulaProfesor = Convert.ToString(reader["CedulaProfesor"]);
                ProfesorSeleccionado.NombreProfesor = Convert.ToString(reader["NombreProfesor"]);
                ProfesorSeleccionado.Apellidos = Convert.ToString(reader["Apellidos"]);
                ProfesorSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                ProfesorSeleccionado.Profesion = Convert.ToString(reader["Profesion"]);
                ProfesorSeleccionado.CorreoElectronico = Convert.ToString(reader["CorreoElectronico"]);
                ProfesorSeleccionado.Edad = Convert.ToInt32(reader["Edad"]);
                ProfesorSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                ProfesorSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                ProfesorSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                ProfesorSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                ProfesorSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodosLosProfesores.Add(ProfesorSeleccionado);
            }

            reader.Close();

            return ListaTodosLosProfesores;
        }


    }
}
