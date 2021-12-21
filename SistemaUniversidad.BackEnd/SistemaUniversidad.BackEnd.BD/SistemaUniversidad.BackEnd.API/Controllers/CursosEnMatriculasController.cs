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
    public class CursosEnMatriculasController : ControllerBase
    {
        private readonly ICursosEnMatriculaService cursosEnMatricula;
        public CursosEnMatriculasController(ICursosEnMatriculaService CursosEnMatriculaService)
        {
            cursosEnMatricula = CursosEnMatriculaService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<CursosEnMatriculaDto> Get()
        {
            List<CursosEnMatricula> ListaTodasLosCursosEnMatricula = cursosEnMatricula.SeleccionarTodos();

            List<CursosEnMatriculaDto> ListaTodasLosCursosEnMatriculaDto = new();

            foreach (var CursosEnMatriculaSeleccionada in ListaTodasLosCursosEnMatricula)
            {
                CursosEnMatriculaDto CursosEnMatriculaDTO = new();

                CursosEnMatriculaDTO.NumeroMatricula = CursosEnMatriculaSeleccionada.NumeroMatricula;
                CursosEnMatriculaDTO.CodigoCurso = CursosEnMatriculaSeleccionada.CodigoCurso;
                CursosEnMatriculaDTO.NumeroCiclo = CursosEnMatriculaSeleccionada.NumeroCiclo;
                CursosEnMatriculaDTO.Activo = CursosEnMatriculaSeleccionada.Activo;

                ListaTodasLosCursosEnMatriculaDto.Add(CursosEnMatriculaDTO);
            }

            return ListaTodasLosCursosEnMatriculaDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            CursosEnMatricula CursosEnMatriculaSeleccionada = new();

            CursosEnMatriculaSeleccionada = cursosEnMatricula.SeleccionarPorId(id);

            if (CursosEnMatriculaSeleccionada.NumeroMatricula is 0)
            {
                return NotFound("Cursos En Matricula no encontrada");
            }

            CursosEnMatriculaDto CursosEnMatriculaDTO = new();

            CursosEnMatriculaDTO.NumeroMatricula = CursosEnMatriculaSeleccionada.NumeroMatricula;
            CursosEnMatriculaDTO.CodigoCurso = CursosEnMatriculaSeleccionada.CodigoCurso;
            CursosEnMatriculaDTO.NumeroCiclo = CursosEnMatriculaSeleccionada.NumeroCiclo;
            CursosEnMatriculaDTO.Activo = CursosEnMatriculaSeleccionada.Activo;

            return Ok(CursosEnMatriculaDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] CursosEnMatriculaDto CursosEnMatriculaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CursosEnMatricula CursosEnMatriculaPorInsertar = new();

            CursosEnMatriculaPorInsertar.NumeroMatricula = CursosEnMatriculaDTO.NumeroMatricula;
            CursosEnMatriculaPorInsertar.CodigoCurso = CursosEnMatriculaDTO.CodigoCurso;
            CursosEnMatriculaPorInsertar.NumeroCiclo = CursosEnMatriculaDTO.NumeroCiclo;

            CursosEnMatriculaPorInsertar.CreadoPor = "Ruiz";

            cursosEnMatricula.Insertar(CursosEnMatriculaPorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CursosEnMatriculaDto CursosEnMatriculaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CursosEnMatricula CursosEnMatriculaSeleccionada = new();

            CursosEnMatriculaSeleccionada = cursosEnMatricula.SeleccionarPorId(id);

            if (CursosEnMatriculaSeleccionada.NumeroMatricula is 0)
            {
                return NotFound("Cursos En Matricula no encontrada");
            }

            CursosEnMatricula CursosEnMatriculaPorActualizar = new();

            CursosEnMatriculaPorActualizar.NumeroMatricula = CursosEnMatriculaDTO.NumeroMatricula;
            CursosEnMatriculaPorActualizar.CodigoCurso = CursosEnMatriculaDTO.CodigoCurso;
            CursosEnMatriculaPorActualizar.NumeroCiclo = CursosEnMatriculaDTO.NumeroCiclo;
            CursosEnMatriculaPorActualizar.Activo = CursosEnMatriculaDTO.Activo;

            CursosEnMatriculaPorActualizar.FechaModificacion = System.DateTime.Now;
            CursosEnMatriculaPorActualizar.ModificadoPor = "Ruiz";

            cursosEnMatricula.Actualizar(CursosEnMatriculaPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            CursosEnMatricula CursosEnMatriculaSeleccionada = new();

            CursosEnMatriculaSeleccionada = cursosEnMatricula.SeleccionarPorId(id);

            if (CursosEnMatriculaSeleccionada.NumeroMatricula is 0)
            {
                return NotFound("Cursos En Matricula no encontrada");
            }

            CursosEnMatriculaSeleccionada.Activo = false;

            cursosEnMatricula.Actualizar(CursosEnMatriculaSeleccionada);

            return Ok("Registro eliminado");
        }
    }
}
