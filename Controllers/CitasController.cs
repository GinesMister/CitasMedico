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
            var citas = _service.GetAllCitas().Result;
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
            {
                return NotFound();
            }

            return Ok(cita);
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.Id)
            {
                return BadRequest();
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCita([FromBody] CitaDTO cita)
        {
            var createdCita = _service.CreateCita(cita).Result;

            if (createdCita == null)
            {
                return BadRequest(ModelState);
            }

            return createdCita;
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.Id == id);
        }
    }
}