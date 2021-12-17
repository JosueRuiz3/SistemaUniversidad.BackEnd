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
    public class CursosConProfesoresRepository : ConexionBD, ICursosConProfesoresRepository
    {
        public CursosConProfesoresRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(CursosConProfesore cursosConProfesore)
        {

            var query = "SP_CursosConProfesores_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCurso", cursosConProfesore.CodigoCurso);
            command.Parameters.AddWithValue("@CedulaProfesor", cursosConProfesore.CedulaProfesor);
            command.Parameters.AddWithValue("@NumeroCiclo", cursosConProfesore.NumeroCiclo);
            command.Parameters.AddWithValue("@ModificadoPor", cursosConProfesore.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", cursosConProfesore.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(CursosConProfesore cursosConProfesore)
        {
            
            var query = "SP_CursosConProfesores_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoCurso", cursosConProfesore.CodigoCurso);
            command.Parameters.AddWithValue("@CedulaProfesor", cursosConProfesore.CedulaProfesor);
            command.Parameters.AddWithValue("@NumeroCiclo", cursosConProfesore.NumeroCiclo);
            command.Parameters.AddWithValue("@CreadoPor", cursosConProfesore.CreadoPor);

            command.ExecuteNonQuery();

        }

        public CursosConProfesore SeleccionarPorId(String CodigoCurso)
        {
            var query = "SELECT * FROM vw_CursosConProfesores_SeleccionarActivos WHERE CodigoCurso = @CodigoCurso";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CodigoCurso", CodigoCurso);

            SqlDataReader reader = command.ExecuteReader();

            CursosConProfesore CursosConProfesoreSeleccionado = new();

            while (reader.Read())
            {
                CursosConProfesoreSeleccionado.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursosConProfesoreSeleccionado.CedulaProfesor = Convert.ToString(reader["CedulaProfesor"]);
                CursosConProfesoreSeleccionado.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CursosConProfesoreSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                CursosConProfesoreSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursosConProfesoreSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursosConProfesoreSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursosConProfesoreSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CursosConProfesoreSeleccionado;
        }

        public List<CursosConProfesore> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_CursosConProfesores_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<CursosConProfesore> ListaTodasLosCursosConProfesore = new List<CursosConProfesore>();

            while (reader.Read())
            {
                CursosConProfesore CursosConProfesoreSeleccionado = new();

                CursosConProfesoreSeleccionado.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursosConProfesoreSeleccionado.CedulaProfesor = Convert.ToString(reader["CedulaProfesor"]);
                CursosConProfesoreSeleccionado.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CursosConProfesoreSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                CursosConProfesoreSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursosConProfesoreSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursosConProfesoreSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursosConProfesoreSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLosCursosConProfesore.Add(CursosConProfesoreSeleccionado);
            }

            reader.Close();

            return ListaTodasLosCursosConProfesore;
        }
    }
}
