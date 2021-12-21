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
    public class MatriculaRepository : ConexionBD, IMatriculasRepository
    {
        public MatriculaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Matricula matricula)
        {

            var query = "SP_Matriculas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroMatricula", matricula.NumeroMatricula);
            command.Parameters.AddWithValue("@NumeroCiclo", matricula.NumeroCiclo);
            command.Parameters.AddWithValue("@MontoMatricula", matricula.MontoMatricula);
            command.Parameters.AddWithValue("@CedulaEstudiante", matricula.CedulaEstudiante);
            command.Parameters.AddWithValue("@ModificadoPor", matricula.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", matricula.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Matricula matricula)
        {
            
            var query = "SP_Matriculas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroMatricula", matricula.NumeroMatricula);
            command.Parameters.AddWithValue("@NumeroCiclo", matricula.NumeroCiclo);
            command.Parameters.AddWithValue("@MontoMatricula", matricula.MontoMatricula);
            command.Parameters.AddWithValue("@CedulaEstudiante", matricula.CedulaEstudiante);
            command.Parameters.AddWithValue("@CreadoPor", matricula.CreadoPor);

            command.ExecuteNonQuery();

        }

        public Matricula SeleccionarPorId(String NumeroMatricula)
        {
            var query = "SELECT * FROM vw_Matriculas_SeleccionarActivos WHERE NumeroMatricula = @NumeroMatricula";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NumeroMatricula", NumeroMatricula);

            SqlDataReader reader = command.ExecuteReader();

            Matricula MatriculaSeleccionada = new();

            while (reader.Read())
            {
                MatriculaSeleccionada.NumeroMatricula = Convert.ToInt32(reader["NumeroMatricula"]);
                MatriculaSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                MatriculaSeleccionada.MontoMatricula = Convert.ToDecimal(reader["MontoMatricula"]);
                MatriculaSeleccionada.CedulaEstudiante = Convert.ToString(reader["CedulaEstudiante"]);
                MatriculaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                MatriculaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                MatriculaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                MatriculaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                MatriculaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return MatriculaSeleccionada;
        }

        public List<Matricula> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_Matriculas_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Matricula> ListaTodasLasMatricula = new List<Matricula>();

            while (reader.Read())
            {
                Matricula MatriculaSeleccionada = new();

                MatriculaSeleccionada.NumeroMatricula = Convert.ToInt32(reader["NumeroMatricula"]);
                MatriculaSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                MatriculaSeleccionada.MontoMatricula = Convert.ToDecimal(reader["MontoMatricula"]);
                MatriculaSeleccionada.CedulaEstudiante = Convert.ToString(reader["CedulaEstudiante"]);
                MatriculaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                MatriculaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                MatriculaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                MatriculaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                MatriculaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLasMatricula.Add(MatriculaSeleccionada);
            }

            reader.Close();

            return ListaTodasLasMatricula;
        }
    }
}
