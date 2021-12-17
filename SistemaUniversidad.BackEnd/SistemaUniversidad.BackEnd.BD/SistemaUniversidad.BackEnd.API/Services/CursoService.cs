using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class CursoService : ICursoService
    {
        private IUnitOfWork BD;
        public CursoService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Curso model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Curso model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Curso SeleccionarPorId(string id)
        {
            Curso CursoSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                CursoSeleccionada = bd.Repositories.CursosRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return CursoSeleccionada;
        }

        public List<Curso> SeleccionarTodos()
        {
            List<Curso> ListaTodasLasCurso;

            using (var bd = BD.Conectar())
            {
                ListaTodasLasCurso = (List<Curso>)bd.Repositories.CursosRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLasCurso;

        }
    }
}
