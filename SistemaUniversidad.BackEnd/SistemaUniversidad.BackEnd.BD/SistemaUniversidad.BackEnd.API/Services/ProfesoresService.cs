using SistemaUniversidad.BackEnd.API.Models;
using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class ProfesoresService : IProfesoresService
    {

        private IUnitOfWork BD;
        public ProfesoresService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Profesore model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.ProfesoresRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.ProfesoresRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Profesore model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.ProfesoresRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Profesore SeleccionarPorId(string id)
        {
            Profesore ProfesorSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                ProfesorSeleccionado = bd.Repositories.ProfesoresRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return ProfesorSeleccionado;
        }

        public List<Profesore> SeleccionarTodos()
        {
            List<Profesore> ListaTodosLosProfesores;

            using (var bd = BD.Conectar())
            {
                ListaTodosLosProfesores = (List<Profesore>)bd.Repositories.ProfesoresRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodosLosProfesores;

        }
    }
}
