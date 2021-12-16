using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class CarreraService : ICarreraService
    {
        private IUnitOfWork BD;
        public CarreraService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Carrera model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CarrerasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CarrerasRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Carrera model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CarrerasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Carrera SeleccionarPorId(string id)
        {
            Carrera CarreraSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                CarreraSeleccionada = bd.Repositories.CarrerasRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return CarreraSeleccionada;
        }

        public List<Carrera> SeleccionarTodos()
        {
            List<Carrera> ListaTodasLasCarrera;

            using (var bd = BD.Conectar())
            {
                ListaTodasLasCarrera = (List<Carrera>)bd.Repositories.CarrerasRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLasCarrera;

        }
    }
}
