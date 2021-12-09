﻿using SistemaUniversidad.BackEnd.API.Models;
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
    public class AulasRepository : ConexionBD, IAulasRepository
    {
        public AulasRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Aula aula)
        {
            var query = "UPDATE Aula SET Horario = @Horario, CodigoCurso  = @CodigoCurso, FechaModificacion = @FechaModificacion, ModificadoPor = @ModificadoPor WHERE NumeroAula = @NumeroAula";
            var command = CreateCommand(query);
            
            command.Parameters.AddWithValue("@Horario", aula.Horario);
            command.Parameters.AddWithValue("@CodigoCurso", aula.CodigoCurso);
            command.Parameters.AddWithValue("@FechaModificacion", aula.FechaModificacion);
            command.Parameters.AddWithValue("@ModificadoPor", aula.ModificadoPor);
            command.Parameters.AddWithValue("@NumeroAula", aula.NumeroAula);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Aula aula)
        {
            
            var query = "SP_Aula_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroAula", aula.NumeroAula);
            command.Parameters.AddWithValue("@Horario", aula.Horario);
            command.Parameters.AddWithValue("@CodigoCurso", aula.CodigoCurso);
            command.Parameters.AddWithValue("@CreadoPor", aula.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Aula SeleccionarPorId(String NumeroAula)
        {
            var query = "SELECT * FROM vw_Aula_SeleccionarActivos WHERE NumeroAula = @NumeroAula";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NumeroAula", NumeroAula);

            SqlDataReader reader = command.ExecuteReader();

            Aula AulaSeleccionada = new();

            while (reader.Read())
            {
                AulaSeleccionada.NumeroAula = Convert.ToString(reader["NumeroAula"]);
                AulaSeleccionada.Horario = Convert.ToString(reader["Horario"]);
                AulaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                AulaSeleccionada.CodigoCurso = Convert.ToString(reader["CodigoCurso"]);
                AulaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                AulaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]); 
                AulaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                AulaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return AulaSeleccionada;
        }

        public IEnumerable<Aula> SeleccionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
