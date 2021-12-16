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
        private readonly ISedeService sedes;
        public SedesController(ISedeService SedesService)
        {
            sedes = SedesService;
        }

        // GET: api/<SedesController>
        [HttpGet]
        public List<SedeDto> Get()
        {
            List<Sede> ListaTodasLasSedes = sedes.SeleccionarTodos();

            List<SedeDto> ListaTodasLasSedesDTO = new();

            foreach (var Sedeseleccionada in ListaTodasLasSedes)
            {
                SedeDto SedeDTo = new();

                SedeDTo.CodigoSede = Sedeseleccionada.CodigoSede;
                SedeDTo.NombreSede = Sedeseleccionada.NombreSede;
                SedeDTo.Telefono = Sedeseleccionada.Telefono;
                SedeDTo.CorreoElectronico = Sedeseleccionada.CorreoElectronico;
                SedeDTo.Direccion = Sedeseleccionada.Direccion;
                SedeDTo.Activo = Sedeseleccionada.Activo;

                ListaTodasLasSedesDTO.Add(SedeDTo);
            }

            return ListaTodasLasSedesDTO;
        }

        // GET api/<SedesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Sede Sedeseleccionada = new();

            Sedeseleccionada = sedes.SeleccionarPorId(id);

            if (Sedeseleccionada.CodigoSede is null)
            {
                return NotFound("Sede no encontrada");
            }

            SedeDto sedeDTO = new();

            sedeDTO.CodigoSede = Sedeseleccionada.CodigoSede;
            sedeDTO.NombreSede = Sedeseleccionada.NombreSede;
            sedeDTO.Telefono = Sedeseleccionada.Telefono;
            sedeDTO.CorreoElectronico = Sedeseleccionada.CorreoElectronico;
            sedeDTO.Direccion = Sedeseleccionada.Direccion;
            sedeDTO.Activo = Sedeseleccionada.Activo;

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

            sedes.Insertar(SedePorInsertar);

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

            SedeSeleccionada = sedes.SeleccionarPorId(id);

            if (SedeSeleccionada.CodigoSede is null)
            {
                return NotFound("Sede no encontrada");
            }

            Sede SedePorActualizar = new();

            SedePorActualizar.CodigoSede = sedeDTO.CodigoSede;
            SedePorActualizar.NombreSede = sedeDTO.NombreSede;
            SedePorActualizar.Telefono = sedeDTO.Telefono;
            SedePorActualizar.CorreoElectronico = sedeDTO.CorreoElectronico;
            SedePorActualizar.Direccion = sedeDTO.Direccion;
            SedePorActualizar.Activo = sedeDTO.Activo;

            SedePorActualizar.FechaModificacion = System.DateTime.Now;
            SedePorActualizar.ModificadoPor = "Ruiz";

            sedes.Actualizar(SedePorActualizar);

            return Ok();
        }

        // DELETE api/<SedesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Sede SedeSeleccionada = new();

            SedeSeleccionada = sedes.SeleccionarPorId(id);

            if (SedeSeleccionada.CodigoSede is null)
            {
                return NotFound("Sede no encontrada");
            }

            SedeSeleccionada.Activo = false;

            sedes.Actualizar(SedeSeleccionada);

            return Ok("Registro eliminado");
        }
    }
}
