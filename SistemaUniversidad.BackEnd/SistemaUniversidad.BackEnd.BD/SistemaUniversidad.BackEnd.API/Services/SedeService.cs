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

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
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
            Sede SeleSeleccionada = new Sede();

            using (var bd = BD.Conectar())
            {
                SeleSeleccionada = bd.Repositories.SedeRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }
            return SeleSeleccionada;
        }

        public IEnumerable<Sede> SeleccionarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
