using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class CursosEnAulaService : ICursosEnAulaService
    {
        private IUnitOfWork BD;
        public CursosEnAulaService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(CursosEnAula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosEnAulasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(string id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosEnAulasRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(CursosEnAula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CursosEnAulasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public CursosEnAula SeleccionarPorId(string id)
        {
            CursosEnAula CursosEnAulaSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                CursosEnAulaSeleccionada = bd.Repositories.CursosEnAulasRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return CursosEnAulaSeleccionada;
        }

        public List<CursosEnAula> SeleccionarTodos()
        {
            List<CursosEnAula> ListaTodasLosCursosEnAula;

            using (var bd = BD.Conectar())
            {
                ListaTodasLosCursosEnAula = (List<CursosEnAula>)bd.Repositories.CursosEnAulasRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLosCursosEnAula;

        }
    }
}
