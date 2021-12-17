using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class CursosConProfesoreService : ICursosConProfesoreService
    {
        private IUnitOfWork BD;
        public CursosConProfesoreService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(CursosConProfesore model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosConProfesoresRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosConProfesoresRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(CursosConProfesore model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosConProfesoresRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public CursosConProfesore SeleccionarPorId(string id)
        {
            CursosConProfesore CursosConProfesoreSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                CursosConProfesoreSeleccionado = bd.Repositories.CursosConProfesoresRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return CursosConProfesoreSeleccionado;
        }

        public List<CursosConProfesore> SeleccionarTodos()
        {
            List<CursosConProfesore> ListaTodasLosCursosConProfesore;

            using (var bd = BD.Conectar())
            {
                ListaTodasLosCursosConProfesore = (List<CursosConProfesore>)bd.Repositories.CursosConProfesoresRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLosCursosConProfesore;

        }
    }
}
