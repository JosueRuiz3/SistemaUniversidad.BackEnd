using Microsoft.AspNetCore.Mvc;
using SistemaUniversidad.BackEnd.API.DTOs;
using SistemaUniversidad.BackEnd.API.Models;
using SistemaUniversidad.BackEnd.API.Services;
using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaUniversidad.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedesController : ControllerBase
    {
        private readonly ISedeService Sede;
        public SedesController(ISedeService SedesService)
        {
            Sede = SedesService;
        }

        // GET: api/<SedesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SedesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Sede Sedeseleccionada = new();

            Sedeseleccionada = Sede.SeleccionarPorId(id);


            if (Sedeseleccionada.CodigoSede is 0)
            {
                return NotFound("Sede no encontrada");
            }

            SedeDto sedeDTO = new();

            return Ok(sedeDTO);
        }

        // POST api/<SedesController>
        [HttpPost]
        public IActionResult Post([FromBody] SedeDto sedeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Sede SedePorInsertar = new();

            SedePorInsertar.CodigoSede = sedeDTO.CodigoSede;
            SedePorInsertar.NombreSede = sedeDTO.NombreSede;
            SedePorInsertar.Telefono = sedeDTO.Telefono;
            SedePorInsertar.CorreoElectronico = sedeDTO.CorreoElectronico;
            SedePorInsertar.Direccion = sedeDTO.Direccion;
            SedePorInsertar.CreadoPor = "Ruiz";

            Sede.Insertar(SedePorInsertar);

            return Ok();
        }

        // PUT api/<SedesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] SedeDto sedeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Sede SedeSeleccionada = new();

            SedeSeleccionada = Sede.SeleccionarPorId(id);

            if (SedeSeleccionada.CodigoSede is 0)
            {
                return NotFound("Sede no encontrada");
            }

            Sede SedePorActualizar = new();

            SedePorActualizar.CodigoSede = sedeDTO.CodigoSede;
            SedePorActualizar.NombreSede = sedeDTO.NombreSede;
            SedePorActualizar.Telefono = sedeDTO.Telefono;
            SedePorActualizar.CorreoElectronico = sedeDTO.CorreoElectronico;
            SedePorActualizar.Direccion = sedeDTO.Direccion;

            SedePorActualizar.FechaModificacion = System.DateTime.Now;
            SedePorActualizar.CreadoPor = "Ruiz";

            return Ok();
        }

        // DELETE api/<SedesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Sede SedeSeleccionada = new Sede();

            SedeSeleccionada = Sede.SeleccionarPorId(id);

            if (SedeSeleccionada.CodigoSede is 0)
            {
                return NotFound("Sede no encontrada");
            }

            SedeSeleccionada.Activo = false;

            Sede.Actualizar(SedeSeleccionada);

            return Ok("Registro eliminado");
        }
    }
}
