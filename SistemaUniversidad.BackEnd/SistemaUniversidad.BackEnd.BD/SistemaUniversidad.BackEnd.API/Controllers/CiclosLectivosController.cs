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
    public class CiclosLectivosController : ControllerBase
    {
        private readonly ICicloLectivoService cicloLectivo;
        public CiclosLectivosController(ICicloLectivoService CicloLectivoService)
        {
            cicloLectivo = CicloLectivoService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<CicloLectivoDto> Get()
        {
            List<CicloLectivo> ListaTodosLosCicloLectivos = cicloLectivo.SeleccionarTodos();

            List<CicloLectivoDto> ListaTodosLosCicloLectivosDto = new();

            foreach (var CicloLectivoSeleccionado in ListaTodosLosCicloLectivos)
            {
                CicloLectivoDto CicloLectivoDTO = new();

                CicloLectivoDTO.NumeroCiclo = CicloLectivoSeleccionado.NumeroCiclo;
                CicloLectivoDTO.NombreCiclo = CicloLectivoSeleccionado.NombreCiclo;
                CicloLectivoDTO.FechaInicio = CicloLectivoSeleccionado.FechaInicio;
                CicloLectivoDTO.FechaFin = CicloLectivoSeleccionado.FechaFin;
                CicloLectivoDTO.Activo = CicloLectivoSeleccionado.Activo;

                ListaTodosLosCicloLectivosDto.Add(CicloLectivoDTO);
            }

            return ListaTodosLosCicloLectivosDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            CicloLectivo CicloLectivoSeleccionado = new();

            CicloLectivoSeleccionado = cicloLectivo.SeleccionarPorId(id);

            if (CicloLectivoSeleccionado.NumeroCiclo is null)
            {
                return NotFound("Numero de Ciclo no encontrado");
            }

            CicloLectivoDto CicloLectivoDTO = new();

            CicloLectivoDTO.NumeroCiclo = CicloLectivoSeleccionado.NumeroCiclo;
            CicloLectivoDTO.NombreCiclo = CicloLectivoSeleccionado.NombreCiclo;
            CicloLectivoDTO.FechaInicio = CicloLectivoSeleccionado.FechaInicio;
            CicloLectivoDTO.FechaFin = CicloLectivoSeleccionado.FechaFin;
            CicloLectivoDTO.Activo = CicloLectivoSeleccionado.Activo;

            return Ok(CicloLectivoDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] CicloLectivoDto CicloLectivoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CicloLectivo CicloLectivoPorInsertar = new();

            CicloLectivoPorInsertar.NumeroCiclo = CicloLectivoDTO.NumeroCiclo;
            CicloLectivoPorInsertar.NombreCiclo = CicloLectivoDTO.NombreCiclo;
            CicloLectivoPorInsertar.FechaInicio = CicloLectivoDTO.FechaInicio;
            CicloLectivoPorInsertar.FechaFin = CicloLectivoDTO.FechaFin;

            CicloLectivoPorInsertar.CreadoPor = "Ruiz";

            cicloLectivo.Insertar(CicloLectivoPorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CicloLectivoDto CicloLectivoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            CicloLectivo CicloLectivoSeleccionado = new();

            CicloLectivoSeleccionado = cicloLectivo.SeleccionarPorId(id);

            if (CicloLectivoSeleccionado.NumeroCiclo is null)
            {
                return NotFound("Numero de Ciclo no encontrado");
            }

            CicloLectivo CicloLectivoPorActualizar = new();

            CicloLectivoPorActualizar.NumeroCiclo = CicloLectivoDTO.NumeroCiclo;
            CicloLectivoPorActualizar.NombreCiclo = CicloLectivoDTO.NombreCiclo;
            CicloLectivoPorActualizar.FechaInicio = CicloLectivoDTO.FechaInicio;
            CicloLectivoPorActualizar.FechaFin = CicloLectivoDTO.FechaFin;
            CicloLectivoPorActualizar.Activo = CicloLectivoDTO.Activo;

            CicloLectivoPorActualizar.FechaModificacion = System.DateTime.Now;
            CicloLectivoPorActualizar.ModificadoPor = "Ruiz";

            cicloLectivo.Actualizar(CicloLectivoPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            CicloLectivo CicloLectivoSeleccionado = new();

            CicloLectivoSeleccionado = cicloLectivo.SeleccionarPorId(id);

            if (CicloLectivoSeleccionado.NumeroCiclo is null)
            {
                return NotFound("Numero de Ciclo no encontrado");
            }

            CicloLectivoSeleccionado.Activo = false;

            cicloLectivo.Actualizar(CicloLectivoSeleccionado);

            return Ok("Registro eliminado");
        }
    }
}
