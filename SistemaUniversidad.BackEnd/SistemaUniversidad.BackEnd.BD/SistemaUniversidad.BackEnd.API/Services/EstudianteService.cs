using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class EstudianteService : IEstudianteService
    {
        private IUnitOfWork BD;
        public EstudianteService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Estudiante model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.EstudiantesRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.EstudiantesRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Estudiante model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.EstudiantesRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Estudiante SeleccionarPorId(string id)
        {
            Estudiante EstudianteSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                EstudianteSeleccionada = bd.Repositories.EstudiantesRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return EstudianteSeleccionada;
        }

        public List<Estudiante> SeleccionarTodos()
        {
            List<Estudiante> ListaTodasLosEstudiante;

            using (var bd = BD.Conectar())
            {
                ListaTodasLosEstudiante = (List<Estudiante>)bd.Repositories.EstudiantesRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLosEstudiante;

        }
    }
}
