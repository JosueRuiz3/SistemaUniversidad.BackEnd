using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class SedeService : ISedeService
    {
        private IUnitOfWork BD;
        public SedeService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }

        public void Actualizar(Sede model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.SedeRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.SedeRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Sede model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.SedeRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Sede SeleccionarPorId(string id)
        {
            Sede SedeSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                SedeSeleccionada = bd.Repositories.SedeRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }
            return SedeSeleccionada;
        }

        public List<Sede> SeleccionarTodos()
        {
            List<Sede> ListaTodasLasAulas;

            using (var bd = BD.Conectar())
            {
                ListaTodasLasAulas = (List<Sede>)bd.Repositories.SedeRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLasAulas;

        }
    }
}
