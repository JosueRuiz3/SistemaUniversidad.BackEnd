using Microsoft.AspNetCore.Mvc;
using SistemaUniversidad.BackEnd.API.Models;
using SistemaUniversidad.BackEnd.API.Dtos;
using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaUniversidad.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesoresService profesore;
        public ProfesoresController(IProfesoresService ProfesoresService)
        {
            profesore = ProfesoresService;
        }

        // GET: api/<ProfesoresController>
        [HttpGet]
        public List<Profesore> Get()
        {
            List<Profesore> ListaTodosLosProfesores = profesore.SeleccionarTodos();

            List<ProfesoreDto> ListaTodosLosProfesoresDto = new();

            foreach (var ProfesorSeleccionado in ListaTodosLosProfesores)
            {
                ProfesoreDto ProfesoreDTo = new();

                ProfesoreDTo.CedulaProfesor = ProfesorSeleccionado.CedulaProfesor;
                ProfesoreDTo.NombreProfesor = ProfesorSeleccionado.NombreProfesor;
                ProfesoreDTo.Apellidos = ProfesorSeleccionado.Apellidos;
                ProfesoreDTo.Telefono = ProfesorSeleccionado.Telefono;
                ProfesoreDTo.Profesion = ProfesorSeleccionado.Profesion;
                ProfesoreDTo.CorreoElectronico = ProfesorSeleccionado.CorreoElectronico;
                ProfesoreDTo.Edad = ProfesorSeleccionado.Edad;
                ProfesoreDTo.Activo = ProfesorSeleccionado.Activo;

                ListaTodosLosProfesoresDto.Add(ProfesoreDTo);
            }

            return ListaTodosLosProfesores;
        }

        // GET api/<ProfesoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Profesore ProfesorSeleccionado = new();

            ProfesorSeleccionado = profesore.SeleccionarPorId(id);

            if (ProfesorSeleccionado.CedulaProfesor is null)
            {
                return NotFound("Profesor no encontrado");
            }

            ProfesoreDto ProfesoreDTo = new();

            ProfesoreDTo.CedulaProfesor = ProfesorSeleccionado.CedulaProfesor;
            ProfesoreDTo.NombreProfesor = ProfesorSeleccionado.NombreProfesor;
            ProfesoreDTo.Apellidos = ProfesorSeleccionado.Apellidos;
            ProfesoreDTo.Telefono = ProfesorSeleccionado.Telefono;
            ProfesoreDTo.Profesion = ProfesorSeleccionado.Profesion;
            ProfesoreDTo.CorreoElectronico = ProfesorSeleccionado.CorreoElectronico;
            ProfesoreDTo.Edad = ProfesorSeleccionado.Edad;
            ProfesoreDTo.Activo = ProfesorSeleccionado.Activo;
            return Ok(ProfesoreDTo);
        }

        // POST api/<ProfesoresController>
        [HttpPost]
        public IActionResult Post([FromBody] ProfesoreDto ProfesoreDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Profesore ProfesorPorInsertar = new();

            ProfesorPorInsertar.CedulaProfesor = ProfesoreDTo.CedulaProfesor;
            ProfesorPorInsertar.NombreProfesor = ProfesoreDTo.NombreProfesor;
            ProfesorPorInsertar.Apellidos = ProfesoreDTo.Apellidos;
            ProfesorPorInsertar.Telefono = ProfesoreDTo.Telefono;
            ProfesorPorInsertar.Profesion = ProfesoreDTo.Profesion;
            ProfesorPorInsertar.CorreoElectronico = ProfesoreDTo.CorreoElectronico;
            ProfesorPorInsertar.Edad = ProfesoreDTo.Edad;

            ProfesorPorInsertar.CreadoPor = "Ruiz";

            profesore.Insertar(ProfesorPorInsertar);

            return Ok();
        }

        // PUT api/<ProfesoreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ProfesoreDto ProfesoreDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Profesore ProfesorSeleccionado = new();

            ProfesorSeleccionado = profesore.SeleccionarPorId(id);

            if (ProfesorSeleccionado.CedulaProfesor is null)
            {
                return NotFound("Profesor no encontrado");
            }

            Profesore ProfesorePorActualizar = new();

            ProfesorePorActualizar.CedulaProfesor = ProfesoreDTo.CedulaProfesor;
            ProfesorePorActualizar.NombreProfesor = ProfesoreDTo.NombreProfesor;
            ProfesorePorActualizar.Apellidos = ProfesoreDTo.Apellidos;
            ProfesorePorActualizar.Telefono = ProfesoreDTo.Telefono;
            ProfesorePorActualizar.Profesion = ProfesoreDTo.Profesion;
            ProfesorePorActualizar.CorreoElectronico = ProfesoreDTo.CorreoElectronico;
            ProfesorePorActualizar.Edad = ProfesoreDTo.Edad;
            ProfesorePorActualizar.Activo = ProfesoreDTo.Activo;

            ProfesorePorActualizar.FechaModificacion = System.DateTime.Now;
            ProfesorePorActualizar.ModificadoPor = "Ruiz";

            profesore.Actualizar(ProfesorePorActualizar);

            return Ok();
        }

        // DELETE api/<ProfesoreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Profesore ProfesorSeleccionado = new();

            ProfesorSeleccionado = profesore.SeleccionarPorId(id);

            if (ProfesorSeleccionado.CedulaProfesor is null)
            {
                return NotFound("profesor no encontrado");
            }

            ProfesorSeleccionado.Activo = false;

            profesore.Actualizar(ProfesorSeleccionado);

            return Ok("Registro eliminado");
        }
    }
}
