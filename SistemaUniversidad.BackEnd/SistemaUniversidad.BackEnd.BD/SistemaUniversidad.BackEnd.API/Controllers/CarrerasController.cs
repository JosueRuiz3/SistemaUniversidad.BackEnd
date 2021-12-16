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
    public class CarrerasController : ControllerBase
    {
        private readonly ICarreraService carrera;
        public CarrerasController(ICarreraService carreraService)
        {
            carrera = carreraService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<CarreraDto> Get()
        {
            List<Carrera> ListaTodasLasCarreras = carrera.SeleccionarTodos();

            List<CarreraDto> ListaTodasLasCarrerasDto = new();

            foreach (var Carrerasleccionada in ListaTodasLasCarreras)
            {
                CarreraDto CarreraDTo = new();

                CarreraDTo.CodigoCarrera = Carrerasleccionada.CodigoCarrera;
                CarreraDTo.NombreCarrera = Carrerasleccionada.NombreCarrera;
                CarreraDTo.Acreditada = Carrerasleccionada.Acreditada;
                CarreraDTo.Activo = Carrerasleccionada.Activo;

                ListaTodasLasCarrerasDto.Add(CarreraDTo);
            }

            return ListaTodasLasCarrerasDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Carrera Carrerasleccionada = new();

            Carrerasleccionada = carrera.SeleccionarPorId(id);

            if (Carrerasleccionada.CodigoCarrera is null)
            {
                return NotFound("Carrera no encontrada");
            }

            CarreraDto CarreraDTo = new();

            CarreraDTo.CodigoCarrera = Carrerasleccionada.CodigoCarrera;
            CarreraDTo.NombreCarrera = Carrerasleccionada.NombreCarrera;
            CarreraDTo.Acreditada = Carrerasleccionada.Acreditada;
            CarreraDTo.Activo = Carrerasleccionada.Activo;

            return Ok(CarreraDTo);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] CarreraDto CarreraDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Carrera CarreraPorInsertar = new();

            CarreraPorInsertar.CodigoCarrera = CarreraDTo.CodigoCarrera;
            CarreraPorInsertar.NombreCarrera = CarreraDTo.NombreCarrera;

            CarreraPorInsertar.CreadoPor = "Ruiz";

            carrera.Insertar(CarreraPorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CarreraDto CarreraDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Carrera Carreraseleccionada = new();

            Carreraseleccionada = carrera.SeleccionarPorId(id);

            if (Carreraseleccionada.CodigoCarrera is null)
            {
                return NotFound("Carrera no encontrada");
            }

            Carrera CarreraPorActualizar = new();

            CarreraPorActualizar.CodigoCarrera = CarreraDTo.CodigoCarrera;
            CarreraPorActualizar.NombreCarrera = CarreraDTo.NombreCarrera;
            CarreraPorActualizar.Acreditada = CarreraDTo.Acreditada;
            CarreraPorActualizar.Activo = CarreraDTo.Activo;

            CarreraPorActualizar.FechaModificacion = System.DateTime.Now;
            CarreraPorActualizar.ModificadoPor = "Ruiz";

            carrera.Actualizar(CarreraPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Carrera Carrerasleccionada = new();

            Carrerasleccionada = carrera.SeleccionarPorId(id);

            if (Carrerasleccionada.CodigoCarrera is null)
            {
                return NotFound("Carrera no encontrada");
            }

            Carrerasleccionada.Activo = false;
            Carrerasleccionada.Acreditada = false;

            carrera.Actualizar(Carrerasleccionada);

            return Ok("Registro eliminado");
        }
    }
}
