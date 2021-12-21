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
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService estudiantes;
        public EstudiantesController(IEstudianteService EstudianteService)
        {
            estudiantes = EstudianteService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<EstudianteDto> Get()
        {
            List<Estudiante> ListaTodasLosEstudiante = estudiantes.SeleccionarTodos();

            List<EstudianteDto> ListaTodasLosEstudianteDto = new();

            foreach (var EstudianteSeleccionada in ListaTodasLosEstudiante)
            {
                EstudianteDto EstudianteDTO = new();

                EstudianteDTO.CedulaEstudiante = EstudianteSeleccionada.CedulaEstudiante;
                EstudianteDTO.Nombre = EstudianteSeleccionada.Nombre;
                EstudianteDTO.Apellidos = EstudianteSeleccionada.Apellidos;
                EstudianteDTO.Telefono = EstudianteSeleccionada.Telefono;
                EstudianteDTO.Direccion = EstudianteSeleccionada.Direccion;
                EstudianteDTO.CorreoElectronico = EstudianteSeleccionada.CorreoElectronico;
                EstudianteDTO.Edad = EstudianteSeleccionada.Edad;
                EstudianteDTO.Activo = EstudianteSeleccionada.Activo;

                ListaTodasLosEstudianteDto.Add(EstudianteDTO);
            }

            return ListaTodasLosEstudianteDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Estudiante EstudianteSeleccionada = new();

            EstudianteSeleccionada = estudiantes.SeleccionarPorId(id);

            if (EstudianteSeleccionada.CedulaEstudiante is null)
            {
                return NotFound("Estudiante no encontrado");
            }

            EstudianteDto EstudianteDTO = new();

            EstudianteDTO.CedulaEstudiante = EstudianteSeleccionada.CedulaEstudiante;
            EstudianteDTO.Nombre = EstudianteSeleccionada.Nombre;
            EstudianteDTO.Apellidos = EstudianteSeleccionada.Apellidos;
            EstudianteDTO.Telefono = EstudianteSeleccionada.Telefono;
            EstudianteDTO.Direccion = EstudianteSeleccionada.Direccion;
            EstudianteDTO.CorreoElectronico = EstudianteSeleccionada.CorreoElectronico;
            EstudianteDTO.Edad = EstudianteSeleccionada.Edad;
            EstudianteDTO.Activo = EstudianteSeleccionada.Activo;

            return Ok(EstudianteDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] EstudianteDto EstudianteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Estudiante EstudiantePorInsertar = new();

            EstudiantePorInsertar.CedulaEstudiante = EstudianteDTO.CedulaEstudiante;
            EstudiantePorInsertar.Nombre = EstudianteDTO.Nombre;
            EstudiantePorInsertar.Apellidos = EstudianteDTO.Apellidos;
            EstudiantePorInsertar.Telefono = EstudianteDTO.Telefono;
            EstudiantePorInsertar.Direccion = EstudianteDTO.Direccion;
            EstudiantePorInsertar.CorreoElectronico = EstudianteDTO.CorreoElectronico;
            EstudiantePorInsertar.Edad = EstudianteDTO.Edad;

            EstudiantePorInsertar.CreadoPor = "Ruiz";

            estudiantes.Insertar(EstudiantePorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] EstudianteDto EstudianteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Estudiante EstudianteSeleccionada = new();

            EstudianteSeleccionada = estudiantes.SeleccionarPorId(id);

            if (EstudianteSeleccionada.CedulaEstudiante is null)
            {
                return NotFound("Estudiante no encontrado");
            }

            Estudiante EstudiantePorActualizar = new();

            EstudiantePorActualizar.CedulaEstudiante = EstudianteDTO.CedulaEstudiante;
            EstudiantePorActualizar.Nombre = EstudianteDTO.Nombre;
            EstudiantePorActualizar.Apellidos = EstudianteDTO.Apellidos;
            EstudiantePorActualizar.Telefono = EstudianteDTO.Telefono;
            EstudiantePorActualizar.Direccion = EstudianteDTO.Direccion;
            EstudiantePorActualizar.CorreoElectronico = EstudianteDTO.CorreoElectronico;
            EstudiantePorActualizar.Edad = EstudianteDTO.Edad;
            EstudiantePorActualizar.Activo = EstudianteDTO.Activo;

            EstudiantePorActualizar.FechaModificacion = System.DateTime.Now;
            EstudiantePorActualizar.ModificadoPor = "Ruiz";

            estudiantes.Actualizar(EstudiantePorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Estudiante EstudianteSeleccionada = new();

            EstudianteSeleccionada = estudiantes.SeleccionarPorId(id);

            if (EstudianteSeleccionada.CedulaEstudiante is null)
            {
                return NotFound("Estudiante no encontrado");
            }

            EstudianteSeleccionada.Activo = false;

            estudiantes.Actualizar(EstudianteSeleccionada);

            return Ok("Registro eliminado");
        }
    }
}
