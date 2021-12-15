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

            var query = "SP_Aulas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroAula", aula.NumeroAula);
            command.Parameters.AddWithValue("@NombreAula", aula.NombreAula);
            command.Parameters.AddWithValue("@ModificadoPor", aula.ModificadoPor);
            command.Parameters.AddWithValue("@Activo", aula.Activo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Aula aula)
        {
            
            var query = "SP_Aulas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NumeroAula", aula.NumeroAula);
            command.Parameters.AddWithValue("@NombreAula", aula.NombreAula);
            command.Parameters.AddWithValue("@CreadoPor", aula.CreadoPor);

            command.ExecuteNonQuery();

        }

        public Aula SeleccionarPorId(String NumeroAula)
        {
            var query = "SELECT * FROM vw_Aulas_SeleccionarActivos WHERE NumeroAula = @NumeroAula";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NumeroAula", NumeroAula);

            SqlDataReader reader = command.ExecuteReader();

            Aula AulaSeleccionada = new();

            while (reader.Read())
            {
                AulaSeleccionada.NumeroAula = Convert.ToString(reader["NumeroAula"]);
                AulaSeleccionada.NombreAula = Convert.ToString(reader["NombreAula"]);
                AulaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                AulaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                AulaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]); 
                AulaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                AulaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return AulaSeleccionada;
        }

        public List<Aula> SeleccionarTodos()
        {

            var query = "SELECT * FROM vw_Aulas_SeleccionarActivos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Aula> ListaTodasLasAulas = new List<Aula>();

            while (reader.Read())
            {
                Aula AulaSeleccionada = new();

                AulaSeleccionada.NumeroAula = Convert.ToString(reader["NumeroAula"]);
                AulaSeleccionada.NombreAula = Convert.ToString(reader["NombreAula"]);
                AulaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                AulaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                AulaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                AulaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                AulaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLasAulas.Add(AulaSeleccionada);
            }

            reader.Close();

            return ListaTodasLasAulas;
        }
    }
}
