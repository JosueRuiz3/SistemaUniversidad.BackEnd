﻿using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class AulaService : IAulasService
    {
        private IUnitOfWork BD;
        public AulaService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Aula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.AulaRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.AulaRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Aula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.AulaRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Aula SeleccionarPorId(string id)
        {
            Aula AulaSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                AulaSeleccionada = bd.Repositories.AulaRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return AulaSeleccionada;
        }

        public List<Aula> SeleccionarTodos()
        {
            List<Aula> ListaTodasLasAulas;

            using (var bd = BD.Conectar())
            {
                ListaTodasLasAulas = (List<Aula>)bd.Repositories.AulaRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLasAulas;

        }
    }
}
