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
    public class CursosEnAulasController : ControllerBase
    {
        private readonly ICursosEnAulaService cursosEnAula;
        public CursosEnAulasController(ICursosEnAulaService cursosEnAulaService)
        {
            cursosEnAula = cursosEnAulaService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<CursosEnAulaDto> Get()
        {
            List<CursosEnAula> ListaTodasLosCursosEnAula = cursosEnAula.SeleccionarTodos();

            List<CursosEnAulaDto> ListaTodasLosCursosEnAulaDto = new();

            foreach (var CursosEnAulaSeleccionada in ListaTodasLosCursosEnAula)
            {
                CursosEnAulaDto CursosEnAulaDTO = new();

                CursosEnAulaDTO.CodigoCurso = CursosEnAulaSeleccionada.CodigoCurso;
                CursosEnAulaDTO.NumeroAula = CursosEnAulaSeleccionada.NumeroAula;
                CursosEnAulaDTO.NumeroCiclo = CursosEnAulaSeleccionada.NumeroCiclo;
                CursosEnAulaDTO.HorarioInicio = CursosEnAulaSeleccionada.HorarioInicio;
                CursosEnAulaDTO.HorarioFin = CursosEnAulaSeleccionada.HorarioFin;
                CursosEnAulaDTO.DiaDeLaSemana = CursosEnAulaSeleccionada.DiaDeLaSemana;
                CursosEnAulaDTO.Activo = CursosEnAulaSeleccionada.Activo;

                ListaTodasLosCursosEnAulaDto.Add(CursosEnAulaDTO);
            }

            return ListaTodasLosCursosEnAulaDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            CursosEnAula CursosEnAulaSeleccionada = new();

            CursosEnAulaSeleccionada = cursosEnAula.SeleccionarPorId(id);

            if (CursosEnAulaSeleccionada.CodigoCurso is null)
            {
                return NotFound("Aula no encontrada");
            }

            CursosEnAulaDto CursosEnAulaDTO = new();

            CursosEnAulaDTO.CodigoCurso = CursosEnAulaSeleccionada.CodigoCurso;
            CursosEnAulaDTO.NumeroAula = CursosEnAulaSeleccionada.NumeroAula;
            CursosEnAulaDTO.NumeroCiclo = CursosEnAulaSeleccionada.NumeroCiclo;
            CursosEnAulaDTO.HorarioInicio = CursosEnAulaSeleccionada.HorarioInicio;
            CursosEnAulaDTO.HorarioFin = CursosEnAulaSeleccionada.HorarioFin;
            CursosEnAulaDTO.DiaDeLaSemana = CursosEnAulaSeleccionada.DiaDeLaSemana;
            CursosEnAulaDTO.Activo = CursosEnAulaSeleccionada.Activo;

            return Ok(CursosEnAulaDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] CursosEnAulaDto CursosEnAulaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CursosEnAula CursosEnAulaInsertar = new();

            CursosEnAulaInsertar.CodigoCurso = CursosEnAulaDTO.CodigoCurso;
            CursosEnAulaInsertar.NumeroAula = CursosEnAulaDTO.NumeroAula;
            CursosEnAulaInsertar.NumeroCiclo = CursosEnAulaDTO.NumeroCiclo;
            CursosEnAulaInsertar.HorarioInicio = CursosEnAulaDTO.HorarioInicio;
            CursosEnAulaInsertar.HorarioFin = CursosEnAulaDTO.HorarioFin;
            CursosEnAulaInsertar.DiaDeLaSemana = CursosEnAulaDTO.DiaDeLaSemana;

            CursosEnAulaInsertar.CreadoPor = "Ruiz";

            cursosEnAula.Insertar(CursosEnAulaInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CursosEnAulaDto CursosEnAulaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CursosEnAula CursosEnAulaSeleccionada = new();

            CursosEnAulaSeleccionada = cursosEnAula.SeleccionarPorId(id);

            if (CursosEnAulaSeleccionada.CodigoCurso is null)
            {
                return NotFound("Curso en Aula no encontrada");
            }

            CursosEnAula CursosEnAulaPorActualizar = new();

            CursosEnAulaPorActualizar.CodigoCurso = CursosEnAulaDTO.CodigoCurso;
            CursosEnAulaPorActualizar.NumeroAula = CursosEnAulaDTO.NumeroAula;
            CursosEnAulaPorActualizar.NumeroCiclo = CursosEnAulaDTO.NumeroCiclo;
            CursosEnAulaPorActualizar.HorarioInicio = CursosEnAulaDTO.HorarioInicio;
            CursosEnAulaPorActualizar.HorarioFin = CursosEnAulaDTO.HorarioFin;
            CursosEnAulaPorActualizar.DiaDeLaSemana = CursosEnAulaDTO.DiaDeLaSemana;
            CursosEnAulaPorActualizar.Activo = CursosEnAulaDTO.Activo;

            CursosEnAulaPorActualizar.FechaModificacion = System.DateTime.Now;
            CursosEnAulaPorActualizar.ModificadoPor = "Ruiz";

            cursosEnAula.Actualizar(CursosEnAulaPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            CursosEnAula CursosEnAulaSeleccionada = new();

            CursosEnAulaSeleccionada = cursosEnAula.SeleccionarPorId(id);

            if (CursosEnAulaSeleccionada.CodigoCurso is null)
            {
                return NotFound("Curso en Aula no encontrada");
            }

            CursosEnAulaSeleccionada.Activo = false;

            cursosEnAula.Actualizar(CursosEnAulaSeleccionada);

            return Ok("Registro eliminado");
        }
    }
}
