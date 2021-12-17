using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class CicloLectivoService : ICicloLectivoService
    {
        private IUnitOfWork BD;
        public CicloLectivoService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(CicloLectivo model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CicloLectivoRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CicloLectivoRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(CicloLectivo model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CicloLectivoRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public CicloLectivo SeleccionarPorId(string id)
        {
            CicloLectivo CicloLectivoSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                CicloLectivoSeleccionada = bd.Repositories.CicloLectivoRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return CicloLectivoSeleccionada;
        }

        public List<CicloLectivo> SeleccionarTodos()
        {
            List<CicloLectivo> ListaTodoLosCiclosLectivos;

            using (var bd = BD.Conectar())
            {
                ListaTodoLosCiclosLectivos = (List<CicloLectivo>)bd.Repositories.CicloLectivoRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodoLosCiclosLectivos;

        }
    }
}
