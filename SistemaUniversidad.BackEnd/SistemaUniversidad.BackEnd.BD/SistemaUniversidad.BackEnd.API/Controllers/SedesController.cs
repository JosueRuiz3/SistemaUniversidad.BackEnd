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
    public class SedesController : ControllerBase
    {
        private readonly ISedeService sede;
        public SedesController(ISedeService SedeService)
        {
            sede = SedeService;
        }

        // GET: api/<AulasController>
        [HttpGet]
        public List<SedeDto> Get()
        {
            List<Sede> ListaTodasLasSede = sede.SeleccionarTodos();

            List<SedeDto> ListaTodasLasSedeDto = new();

            foreach (var SedeSeleccionada in ListaTodasLasSede)
            {
                SedeDto SedeDTO = new();

                SedeDTO.CodigoSede = SedeSeleccionada.CodigoSede;
                SedeDTO.NombreSede = SedeSeleccionada.NombreSede;
                SedeDTO.Telefono = SedeSeleccionada.Telefono;
                SedeDTO.CorreoElectronico = SedeSeleccionada.CorreoElectronico;
                SedeDTO.Direccion = SedeSeleccionada.Direccion;
                SedeDTO.Activo = SedeSeleccionada.Activo;

                ListaTodasLasSedeDto.Add(SedeDTO);
            }

            return ListaTodasLasSedeDto;
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Sede SedeSeleccionada = new();

            SedeSeleccionada = sede.SeleccionarPorId(id);

            if (SedeSeleccionada.CodigoSede is null)
            {
                return NotFound("Sede no encontrada");
            }

            SedeDto SedeDTO = new();

            SedeDTO.CodigoSede = SedeSeleccionada.CodigoSede;
            SedeDTO.NombreSede = SedeSeleccionada.NombreSede;
            SedeDTO.Telefono = SedeSeleccionada.Telefono;
            SedeDTO.CorreoElectronico = SedeSeleccionada.CorreoElectronico;
            SedeDTO.Direccion = SedeSeleccionada.Direccion;
            SedeDTO.Activo = SedeSeleccionada.Activo;

            return Ok(SedeDTO);
        }

        // POST api/<AulasController>
        [HttpPost]
        public IActionResult Post([FromBody] SedeDto SedeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Sede SedePorInsertar = new();

            SedePorInsertar.CodigoSede = SedeDTO.CodigoSede;
            SedePorInsertar.NombreSede = SedeDTO.NombreSede;
            SedePorInsertar.Telefono = SedeDTO.Telefono;
            SedePorInsertar.CorreoElectronico = SedeDTO.CorreoElectronico;
            SedePorInsertar.Direccion = SedeDTO.Direccion;

            SedePorInsertar.CreadoPor = "Ruiz";

            sede.Insertar(SedePorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] SedeDto SedeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Sede SedeSeleccionada = new();

            SedeSeleccionada = sede.SeleccionarPorId(id);

            if (SedeSeleccionada.CodigoSede is null)
            {
                return NotFound("Sede no encontrada");
            }

            Sede SedePorActualizar = new();

            SedePorActualizar.CodigoSede = SedeDTO.CodigoSede;
            SedePorActualizar.NombreSede = SedeDTO.NombreSede;
            SedePorActualizar.Telefono = SedeDTO.Telefono;
            SedePorActualizar.CorreoElectronico = SedeDTO.CorreoElectronico;
            SedePorActualizar.Direccion = SedeDTO.Direccion;
            SedePorActualizar.Activo = SedeDTO.Activo;

            SedePorActualizar.FechaModificacion = System.DateTime.Now;
            SedePorActualizar.ModificadoPor = "Ruiz";

            sede.Actualizar(SedePorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Sede SedeSeleccionada = new();

            SedeSeleccionada = sede.SeleccionarPorId(id);

            if (SedeSeleccionada.CodigoSede is null)
            {
                return NotFound("Sede no encontrada");
            }

            SedeSeleccionada.Activo = false;

            sede.Actualizar(SedeSeleccionada);

            return Ok("Registro eliminado");
        }
    }
}
