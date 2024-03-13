using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasMedico.Data;
using CitasMedico.Models;
using CitasMedico.Services;
using CitasMedico.DTOs;

namespace CitasMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : Controller
    {
        private readonly CitaService _service;

        public CitasController(CitaService service)
        {
            _service = service;
        }

        // GET: api/Citas
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Cita))]
        public IActionResult GetAllCitas()
        {
            Task<IEnumerable<CitaDTO>>? citas = _service.GetAllCitas();
            if (citas == null)
            {
                return Ok();
            }
            return Ok(citas);
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Cita))]
        [ProducesResponseType(400)]
        public IActionResult GetCitaById(int id)
        {
            var cita = _service.GetCitaById(id).Result;

            if (cita == null)
                return NotFound();

            return Ok(cita);
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCita(int id, [FromBody]CitaDTO cita)
        {
            if (id != cita.Id)
                return BadRequest();

            if (cita == null)
                return BadRequest();

            if (_service.GetCitaById(id) == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_service.UpdateCita(cita).Result);
        }

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCita([FromBody]CitaDTO cita)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCita = _service.CreateCita(cita).Result;

            if (createdCita == null)
                return BadRequest(ModelState);

            return Ok(createdCita);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCitaById(int id)
        {
            if (GetCitaById(id) == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_service.DeleteCitaById(id).Result);
        }
    }
}