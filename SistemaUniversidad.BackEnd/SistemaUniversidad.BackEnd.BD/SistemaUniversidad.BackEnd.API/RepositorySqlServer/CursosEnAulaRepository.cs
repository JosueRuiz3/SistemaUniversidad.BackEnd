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
    public class CursosEnAulaRepository : ConexionBD, ICursosEnAulasRepository
    {
        public CursosEnAulaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(CursosEnAula cursosEnAula)
        {

            var query = "SP_CursosEnAulas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroAula", cursosEnAula.CodigoCurso);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.NumeroAula);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.NumeroCiclo);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.HorarioInicio);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.HorarioFin);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.DiaDeLaSemana);
            command.Parameters.AddWithValue("@ModificadoPor", cursosEnAula.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", cursosEnAula.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(CursosEnAula cursosEnAula)
        {
            
            var query = "SP_CursosEnAulas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroAula", cursosEnAula.CodigoCurso);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.NumeroAula);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.NumeroCiclo);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.HorarioInicio);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.HorarioFin);
            command.Parameters.AddWithValue("@NombreAula", cursosEnAula.DiaDeLaSemana);
            command.Parameters.AddWithValue("@CreadoPor", cursosEnAula.CreadoPor);

            command.ExecuteNonQuery();

        }

        public CursosEnAula SeleccionarPorId(String CodigoCurso)
        {
            var query = "SELECT * FROM vw_CursosEnAulas_SeleccionarActivos WHERE CodigoCurso = @CodigoCurso";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CodigoCurso", CodigoCurso);

            SqlDataReader reader = command.ExecuteReader();

            CursosEnAula CursosEnAulaSeleccionada = new();

            while (reader.Read())
            {
                CursosEnAulaSeleccionada.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursosEnAulaSeleccionada.NumeroAula = Convert.ToString(reader["NumeroAula"]);
                CursosEnAulaSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CursosEnAulaSeleccionada.HorarioInicio = Convert.ToString(reader["HorarioInicio"]);
                CursosEnAulaSeleccionada.HorarioFin = Convert.ToString(reader["HorarioFin"]);
                CursosEnAulaSeleccionada.DiaDeLaSemana = Convert.ToString(reader["DiaDeLaSemana"]);
                CursosEnAulaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CursosEnAulaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursosEnAulaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursosEnAulaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursosEnAulaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CursosEnAulaSeleccionada;
        }

        public List<CursosEnAula> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_CursosEnAulas_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<CursosEnAula> ListaTodasLosCursosEnAula = new List<CursosEnAula>();

            while (reader.Read())
            {
                CursosEnAula CursosEnAulaSeleccionada = new();

                CursosEnAulaSeleccionada.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                CursosEnAulaSeleccionada.NumeroAula = Convert.ToString(reader["NumeroAula"]);
                CursosEnAulaSeleccionada.NumeroCiclo = Convert.ToString(reader["NumeroCiclo"]);
                CursosEnAulaSeleccionada.HorarioInicio = Convert.ToString(reader["HorarioInicio"]);
                CursosEnAulaSeleccionada.HorarioFin = Convert.ToString(reader["HorarioFin"]);
                CursosEnAulaSeleccionada.DiaDeLaSemana = Convert.ToString(reader["DiaDeLaSemana"]);
                CursosEnAulaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CursosEnAulaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CursosEnAulaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CursosEnAulaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CursosEnAulaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLosCursosEnAula.Add(CursosEnAulaSeleccionada);
            }

            reader.Close();

            return ListaTodasLosCursosEnAula;
        }
    }
}
