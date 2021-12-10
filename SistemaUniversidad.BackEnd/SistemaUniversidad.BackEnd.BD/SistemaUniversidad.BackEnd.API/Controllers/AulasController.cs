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
    public class AulasController : ControllerBase
    {
        private readonly IAulasService Aulas;
        public AulasController(IAulasService AulasService)
        {
            Aulas = AulasService;
        }
        // GET: api/<AulasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Aula Aulaseleccionada = new();

            Aulaseleccionada = Aulas.SeleccionarPorId(id);

            if (Aulaseleccionada.NumeroAula is null)
            {
                return NotFound("Aula no encontrada");
            }

            AulaDto AulaDTO = new();

            AulaDTO.NumeroAula = Aulaseleccionada.NumeroAula;
            AulaDTO.NombreAula = Aulaseleccionada.NombreAula;
            AulaDTO.CreadoPor = Aulaseleccionada.CreadoPor;

            return Ok(AulaDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] AulaDto AulaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Aula AulaPorInsertar = new();

            AulaPorInsertar.NumeroAula = AulaDTO.NumeroAula;
            AulaPorInsertar.NombreAula = AulaDTO.NombreAula;
            AulaPorInsertar.CreadoPor = "Ruiz";

            Aulas.Insertar(AulaPorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] AulaDto AulaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Aula Aulaseleccionada = new();

            Aulaseleccionada = Aulas.SeleccionarPorId(id);

            if (Aulaseleccionada.NumeroAula is null)
            {
                return NotFound("Aula no encontrada");
            }

            Aula AulaPorActualizar = new();

            AulaPorActualizar.NumeroAula = AulaDTO.NumeroAula;
            AulaPorActualizar.NombreAula = AulaDTO.NombreAula;
            AulaPorActualizar.CreadoPor = AulaDTO.CreadoPor;

            AulaPorActualizar.FechaModificacion = System.DateTime.Now;
            AulaPorActualizar.ModificadoPor = "Ruiz";
           
            Aulas.Actualizar(AulaPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Aula Aulaseleccionada = new();

            Aulaseleccionada = Aulas.SeleccionarPorId(id);

            if (Aulaseleccionada.NumeroAula is null)
            {
                return NotFound("Aula no encontrada");
            }

            Aulaseleccionada.Activo = false; //Esto realiza el eliminado lógico

            Aulas.Actualizar(Aulaseleccionada);

            return Ok("Registro eliminado");
        }
    }
}
