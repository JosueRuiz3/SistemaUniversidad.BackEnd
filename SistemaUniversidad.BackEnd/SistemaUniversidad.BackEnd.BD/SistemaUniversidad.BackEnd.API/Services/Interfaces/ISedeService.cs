﻿using System.Collections.Generic;
using SistemaUniversidad.BackEnd.API.Models;

namespace SistemaUniversidad.BackEnd.API.Services.Interfaces
{
    public interface ISedeService
    {
        IEnumerable<Sede> SeleccionarTodos();
        Sede SeleccionarPorId(string id);
        void Insertar(Sede model);
        void Actualizar(Sede model);
        void Eliminar(int id);

    }
}
