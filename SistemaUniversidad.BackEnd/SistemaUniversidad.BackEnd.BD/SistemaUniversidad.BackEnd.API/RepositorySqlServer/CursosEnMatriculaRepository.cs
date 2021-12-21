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
    public class CursosEnMatriculaRepository : ConexionBD, ICursosEnMatriculasRepository
    {
        public CursosEnMatriculaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(CursosEnMatricula cursosEnMatricula)
        {

            var query = "SP_CursosEnMatriculas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroMatricula", cursosEnMatricula.NumeroMatricula);
            command.Parameters.AddWithValue("@CodigoCurso", cursosEnMatricula.CodigoCurso);
            command.Parameters.AddWithValue("@NumeroCiclo", cursosEnMatricula.NumeroCiclo);
            command.Parameters.AddWithValue("@ModificadoPor", cursosEnMatricula.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", cursosEnMatricula.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(CursosEnMatricula cursosEnMatricula)
        {
            
            var query = "SP_CursosEnMatriculas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroMatricula", cursosEnMatricula.NumeroMatricula);
            command.Parameters.AddWithValue("@CodigoCurso", cursosEnMatricula.CodigoCurso);
            command.Parameters.AddWithValue("@NumeroCiclo", cursosEnMatricula.NumeroCiclo);
            command.Parameters.AddWithValue("@CreadoPor", cursosEnMatricula.CreadoPor);

            command.ExecuteNonQuery();

        }

        public CursosEnMatricula SeleccionarPorId(String NumeroMatricula)
        {
            var query = "SELECT * FROM vw_CursosEnMatriculas_SeleccionarActivos WHERE NumeroMatricula = @NumeroMatricula";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NumeroMatricula", NumeroMatricula);

            SqlDataReader reader = command.ExecuteReader();

            CursosEnMatricula CursosEnMatriculaSeleccionada = new();

            while (reader.Read())
            {
                CursosEnMatriculaSeleccionada.NumeroMatricula = Convert.ToInt32(reader["NumeroMatricula"]);
                CursosEnMatriculaSeleccionada.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursosEnMatriculaSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CursosEnMatriculaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CursosEnMatriculaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursosEnMatriculaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursosEnMatriculaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursosEnMatriculaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CursosEnMatriculaSeleccionada;
        }

        public List<CursosEnMatricula> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_CursosEnMatriculas_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<CursosEnMatricula> ListaTodasLosCursosEnMatricula = new List<CursosEnMatricula>();

            while (reader.Read())
            {
                CursosEnMatricula CursosEnMatriculaSeleccionada = new();

                CursosEnMatriculaSeleccionada.NumeroMatricula = Convert.ToInt32(reader["NumeroMatricula"]);
                CursosEnMatriculaSeleccionada.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursosEnMatriculaSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CursosEnMatriculaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CursosEnMatriculaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursosEnMatriculaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursosEnMatriculaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursosEnMatriculaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLosCursosEnMatricula.Add(CursosEnMatriculaSeleccionada);
            }

            reader.Close();

            return ListaTodasLosCursosEnMatricula;
        }
    }
}
