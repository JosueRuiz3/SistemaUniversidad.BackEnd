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
    public class CursosController : ControllerBase
    {
        private readonly ICursoService curso;
        public CursosController(ICursoService CursoService)
        {
            curso = CursoService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<CursoDto> Get()
        {
            List<Curso> ListaTodosLosCursos = curso.SeleccionarTodos();

            List<CursoDto> ListaTodosLosCursosDTO = new();

            foreach (var CursoSeleccionado in ListaTodosLosCursos)
            {
                CursoDto CursoDTO = new();

                CursoDTO.CodigoCurso = CursoSeleccionado.CodigoCurso;
                CursoDTO.NombreCurso = CursoSeleccionado.NombreCurso;
                CursoDTO.Precio = CursoSeleccionado.Precio;
                CursoDTO.Activo = CursoSeleccionado.Activo;
                ListaTodosLosCursosDTO.Add(CursoDTO);
            }

            return ListaTodosLosCursosDTO;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Curso CursoSeleccionado = new();

            CursoSeleccionado = curso.SeleccionarPorId(id);

            if (CursoSeleccionado.CodigoCurso is null)
            {
                return NotFound("Curso no encontrada");
            }

            CursoDto CursoDTO = new();

            CursoDTO.CodigoCurso = CursoSeleccionado.CodigoCurso;
            CursoDTO.NombreCurso = CursoSeleccionado.NombreCurso;
            CursoDTO.Precio = CursoSeleccionado.Precio;
            CursoDTO.Activo = CursoSeleccionado.Activo;

            return Ok(CursoDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] CursoDto CursoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Curso CursoPorInsertar = new();

            CursoPorInsertar.CodigoCurso = CursoDTO.CodigoCurso;
            CursoPorInsertar.NombreCurso = CursoDTO.NombreCurso;
            CursoPorInsertar.Precio = CursoDTO.Precio;

            CursoPorInsertar.CreadoPor = "Ruiz";

            curso.Insertar(CursoPorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CursoDto CursoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Curso CursoSeleccionado = new();

            CursoSeleccionado = curso.SeleccionarPorId(id);

            if (CursoSeleccionado.CodigoCurso is null)
            {
                return NotFound("Curso no encontrada");
            }

            Curso CursoPorActualizar = new();

            CursoPorActualizar.CodigoCurso = CursoDTO.CodigoCurso;
            CursoPorActualizar.NombreCurso = CursoDTO.NombreCurso;
            CursoPorActualizar.Precio = CursoDTO.Precio;
            CursoPorActualizar.Activo = CursoDTO.Activo;

            CursoPorActualizar.FechaModificacion = System.DateTime.Now;
            CursoPorActualizar.ModificadoPor = "Ruiz";

            curso.Actualizar(CursoPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Curso CursoSeleccionado = new();

            CursoSeleccionado = curso.SeleccionarPorId(id);

            if (CursoSeleccionado.CodigoCurso is null)
            {
                return NotFound("Curso no encontrada");
            }

            CursoSeleccionado.Activo = false;

            curso.Actualizar(CursoSeleccionado);

            return Ok("Registro eliminado");
        }
    }
}
