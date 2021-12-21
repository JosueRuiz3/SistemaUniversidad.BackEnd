using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class CursosEnMatriculaService : ICursosEnMatriculaService
    {
        private IUnitOfWork BD;
        public CursosEnMatriculaService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(CursosEnMatricula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosEnMatriculasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosEnMatriculasRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(CursosEnMatricula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosEnMatriculasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public CursosEnMatricula SeleccionarPorId(string id)
        {
            CursosEnMatricula CursosEnMatriculaSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                CursosEnMatriculaSeleccionada = bd.Repositories.CursosEnMatriculasRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return CursosEnMatriculaSeleccionada;
        }

        public List<CursosEnMatricula> SeleccionarTodos()
        {
            List<CursosEnMatricula> ListaTodasLosCursosEnMatricula;

            using (var bd = BD.Conectar())
            {
                ListaTodasLosCursosEnMatricula = (List<CursosEnMatricula>)bd.Repositories.CursosEnMatriculasRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLosCursosEnMatricula;

        }
    }
}
