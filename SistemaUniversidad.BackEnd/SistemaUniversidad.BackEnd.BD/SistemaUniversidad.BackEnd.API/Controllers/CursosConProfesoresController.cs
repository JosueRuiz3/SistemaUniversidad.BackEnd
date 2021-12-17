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
    public class CursosConProfesoresController : ControllerBase
    {
        private readonly ICursosConProfesoreService cursosConProfesores;
        public CursosConProfesoresController(ICursosConProfesoreService CursosConProfesoreService)
        {
            cursosConProfesores = CursosConProfesoreService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<CursosConProfesoreDto> Get()
        {
            List<CursosConProfesore> ListaTodasLosCursosConProfesore = cursosConProfesores.SeleccionarTodos();

            List<CursosConProfesoreDto> ListaTodasLosCursosConProfesoreDto = new();

            foreach (var CursosConProfesoreSeleccionado in ListaTodasLosCursosConProfesore)
            {
                CursosConProfesoreDto CursosConProfesoreDTO = new();

                CursosConProfesoreDTO.CodigoCurso = CursosConProfesoreSeleccionado.CodigoCurso;
                CursosConProfesoreDTO.CedulaProfesor = CursosConProfesoreSeleccionado.CedulaProfesor;
                CursosConProfesoreDTO.NumeroCiclo = CursosConProfesoreSeleccionado.NumeroCiclo;
                CursosConProfesoreDTO.Activo = CursosConProfesoreSeleccionado.Activo;

                ListaTodasLosCursosConProfesoreDto.Add(CursosConProfesoreDTO);
            }

            return ListaTodasLosCursosConProfesoreDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            CursosConProfesore CursosConProfesoreSeleccionado = new();

            CursosConProfesoreSeleccionado = cursosConProfesores.SeleccionarPorId(id);

            if (CursosConProfesoreSeleccionado.CodigoCurso is null)
            {
                return NotFound("Cursos con Profesor no encontrado");
            }

            CursosConProfesoreDto CursosConProfesoreDTO = new();

            CursosConProfesoreDTO.CodigoCurso = CursosConProfesoreSeleccionado.CodigoCurso;
            CursosConProfesoreDTO.CedulaProfesor = CursosConProfesoreSeleccionado.CedulaProfesor;
            CursosConProfesoreDTO.NumeroCiclo = CursosConProfesoreSeleccionado.NumeroCiclo;
            CursosConProfesoreDTO.Activo = CursosConProfesoreSeleccionado.Activo;

            return Ok(CursosConProfesoreDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] CursosConProfesoreDto CursosConProfesoreDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CursosConProfesore CursosConProfesorePorInsertar = new();

            CursosConProfesorePorInsertar.CodigoCurso = CursosConProfesoreDTO.CodigoCurso;
            CursosConProfesorePorInsertar.CedulaProfesor = CursosConProfesoreDTO.CedulaProfesor;
            CursosConProfesorePorInsertar.NumeroCiclo = CursosConProfesoreDTO.NumeroCiclo;

            CursosConProfesorePorInsertar.CreadoPor = "Ruiz";

            cursosConProfesores.Insertar(CursosConProfesorePorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CursosConProfesoreDto CursosConProfesoreDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CursosConProfesore CursosConProfesoreSeleccionado = new();

            CursosConProfesoreSeleccionado = cursosConProfesores.SeleccionarPorId(id);

            if (CursosConProfesoreSeleccionado.CodigoCurso is null)
            {
                return NotFound("Cursos con Profesor no encontrado");
            }

            CursosConProfesore CursosConProfesorePorActualizar = new();

            CursosConProfesorePorActualizar.CodigoCurso = CursosConProfesoreDTO.CodigoCurso;
            CursosConProfesorePorActualizar.CedulaProfesor = CursosConProfesoreDTO.CedulaProfesor;
            CursosConProfesorePorActualizar.NumeroCiclo = CursosConProfesoreDTO.NumeroCiclo;
            CursosConProfesorePorActualizar.Activo = CursosConProfesoreDTO.Activo;

            CursosConProfesorePorActualizar.FechaModificacion = System.DateTime.Now;
            CursosConProfesorePorActualizar.ModificadoPor = "Ruiz";

            cursosConProfesores.Actualizar(CursosConProfesorePorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            CursosConProfesore CursosConProfesoreSeleccionado = new();

            CursosConProfesoreSeleccionado = cursosConProfesores.SeleccionarPorId(id);

            if (CursosConProfesoreSeleccionado.CodigoCurso is null)
            {
                return NotFound("Cursos con Profesor no encontrado");
            }

            CursosConProfesoreSeleccionado.Activo = false;

            cursosConProfesores.Actualizar(CursosConProfesoreSeleccionado);

            return Ok("Registro eliminado");
        }
    }
}
