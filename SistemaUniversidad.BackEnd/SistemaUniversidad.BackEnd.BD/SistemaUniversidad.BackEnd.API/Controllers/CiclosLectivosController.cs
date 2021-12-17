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
        private readonly ICicloLectivoService ciclolectivo;
        public CiclosLectivosController(ICicloLectivoService CicloLectivoService)
        {
            ciclolectivo = CicloLectivoService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<CicloLectivoDto> Get()
        {
            List<CicloLectivo> ListaTodoLosCiclosLectivos = ciclolectivo.SeleccionarTodos();

            List<CicloLectivoDto> ListaTodosLosCicloLectivoDto = new();

            foreach (var CicloLectivoSeleccionada in ListaTodoLosCiclosLectivos)
            {
                CicloLectivoDto CicloLectivoDTO = new();

                CicloLectivoDTO.NumeroCiclo = CicloLectivoSeleccionada.NumeroCiclo;
                CicloLectivoDTO.NombreCiclo = CicloLectivoSeleccionada.NombreCiclo;
                CicloLectivoDTO.FechaInicio = CicloLectivoSeleccionada.FechaInicio;
                CicloLectivoDTO.FechaFin = CicloLectivoSeleccionada.FechaFin;
                CicloLectivoDTO.Activo = CicloLectivoSeleccionada.Activo;

                ListaTodosLosCicloLectivoDto.Add(CicloLectivoDTO);
            }

            return ListaTodosLosCicloLectivoDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            CicloLectivo CicloLectivoSeleccionada = new();

            CicloLectivoSeleccionada = ciclolectivo.SeleccionarPorId(id);

            if (CicloLectivoSeleccionada.NumeroCiclo is null)
            {
                return NotFound("Ciclo Lectivo no encontrado");
            }

            CicloLectivoDto CicloLectivoDTO = new();

            CicloLectivoDTO.NumeroCiclo = CicloLectivoSeleccionada.NumeroCiclo;
            CicloLectivoDTO.NombreCiclo = CicloLectivoSeleccionada.NombreCiclo;
            CicloLectivoDTO.FechaInicio = CicloLectivoSeleccionada.FechaInicio;
            CicloLectivoDTO.FechaFin = CicloLectivoSeleccionada.FechaFin;
            CicloLectivoDTO.Activo = CicloLectivoSeleccionada.Activo;

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

            ciclolectivo.Insertar(CicloLectivoPorInsertar);

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

            CicloLectivo CicloLectivoSeleccionada = new();

            CicloLectivoSeleccionada = ciclolectivo.SeleccionarPorId(id);

            if (CicloLectivoSeleccionada.NumeroCiclo is null)
            {
                return NotFound("Ciclo Lectivo no encontrada");
            }

            CicloLectivo CicloLectivoPorActualizar = new();

            CicloLectivoPorActualizar.NumeroCiclo = CicloLectivoDTO.NumeroCiclo;
            CicloLectivoPorActualizar.NombreCiclo = CicloLectivoDTO.NombreCiclo;
            CicloLectivoPorActualizar.FechaInicio = CicloLectivoDTO.FechaInicio;
            CicloLectivoPorActualizar.FechaFin = CicloLectivoDTO.FechaFin;
            CicloLectivoPorActualizar.Activo = CicloLectivoDTO.Activo;

            CicloLectivoPorActualizar.FechaModificacion = System.DateTime.Now;
            CicloLectivoPorActualizar.ModificadoPor = "Ruiz";
           
            ciclolectivo.Actualizar(CicloLectivoPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            CicloLectivo CicloLectivoSeleccionada = new();

            CicloLectivoSeleccionada = ciclolectivo.SeleccionarPorId(id);

            if (CicloLectivoSeleccionada.NumeroCiclo is null)
            {
                return NotFound("Ciclo Lectivo no encontrado");
            }

            CicloLectivoSeleccionada.Activo = false;

            ciclolectivo.Actualizar(CicloLectivoSeleccionada);

            return Ok("Registro eliminado");
        }
    }
}
