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
    public class CursosRepository : ConexionBD, ICursosRepository
    {
        public CursosRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }


        public void Actualizar(Curso curso)
        {
            var query = "SP_Cursos_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCurso", curso.CodigoCurso);
            command.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
            command.Parameters.AddWithValue("@Precio", curso.Precio);
            command.Parameters.AddWithValue("@ModificadoPor", curso.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", curso.Activo);

            command.ExecuteNonQuery();

        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Curso curso)
        {
            var query = "SP_Cursos_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCurso", curso.CodigoCurso);
            command.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
            command.Parameters.AddWithValue("@Precio", curso.Precio);
            command.Parameters.AddWithValue("@CreadoPor", curso.CreadoPor);

            command.ExecuteNonQuery();
        }

        public Curso SeleccionarPorId(String CodigoCurso)
        {
            var query = "SELECT * FROM vw_Cursos_SeleccionarActivos WHERE CodigoCurso = @CodigoCurso";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CodigoCurso", CodigoCurso);

            SqlDataReader reader = command.ExecuteReader();

            Curso CursoSeleccionado = new();

            while (reader.Read())
            {
                CursoSeleccionado.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursoSeleccionado.NombreCurso = Convert.ToString(reader["NombreCurso"]);
                CursoSeleccionado.Precio = Convert.ToDecimal(reader["Precio"]);
                CursoSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                CursoSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursoSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursoSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursoSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CursoSeleccionado;
        }

        public List<Curso> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_Cursos_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Curso> ListaTodosLosCursos = new List<Curso>();

            while (reader.Read())
            {
                Curso CursoSeleccionado = new();

                CursoSeleccionado.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursoSeleccionado.NombreCurso = Convert.ToString(reader["NombreCurso"]);
                CursoSeleccionado.Precio = Convert.ToDecimal(reader["Precio"]);
                CursoSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                CursoSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursoSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursoSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursoSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);
                ListaTodosLosCursos.Add(CursoSeleccionado);
            }

            reader.Close();

            return ListaTodosLosCursos;
        }



    }
}
