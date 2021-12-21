using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class MatriculaService : IMatriculaService
    {
        private IUnitOfWork BD;
        public MatriculaService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Matricula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.MatriculasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.MatriculasRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Matricula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.MatriculasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Matricula SeleccionarPorId(string id)
        {
            Matricula MatriculaSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                MatriculaSeleccionada = bd.Repositories.MatriculasRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return MatriculaSeleccionada;
        }

        public List<Matricula> SeleccionarTodos()
        {
            List<Matricula> ListaTodasLasMatricula;

            using (var bd = BD.Conectar())
            {
                ListaTodasLasMatricula = (List<Matricula>)bd.Repositories.MatriculasRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLasMatricula;

        }
    }
}
