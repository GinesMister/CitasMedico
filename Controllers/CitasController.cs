using Microsoft.AspNetCore.Mvc;
using CitasMedico.Models;
using CitasMedico.Services;
using CitasMedico.DTOs;
using CitasMedico.Exceptions;

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
        [ProducesResponseType(200, Type = typeof(IEnumerable<CitaDTO>))]
        public IActionResult GetAllCitas()
        {
            return Ok(_service.GetAllCitas());
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Cita))]
        [ProducesResponseType(400)]
        public IActionResult GetCitaById(int id)
        {
            try
            {
                var response = _service.GetCitaById(id);
                return Ok(response);
            }
            catch (ServiceException ex)
            {
                if (ex.Error == ErrorType.NotFound)
                    return NotFound(ex.Message);
            }
            return BadRequest();
        }

        // PUT: api/Citas/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCita(int id, [FromBody]CitaDTO cita)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = _service.UpdateCita(id, cita);
                return Ok(result);
            }
            catch (ServiceException ex)
            {
                switch (ex.Error)
                {
                    case ErrorType.NotFound:
                        return NotFound(ex.Message);
                    case ErrorType.BadRequest:
                        return BadRequest(ex.Message);
                    default:
                        return BadRequest(ex.Message);
                }
            }

        }

        // POST: api/Citas
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCita([FromBody]CitaDTO cita)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.CreateCita(cita);
                return Created();
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCitaById(int id)
        {
            try
            {
                _service.DeleteCitaById(id);
                return NoContent();
            }
            catch (ServiceException ex)
            {
                switch(ex.Error)
                { 
                    case ErrorType.NotFound: 
                        return NotFound(ex.Message);
                    default:
                        return BadRequest(ex.Message);
                }
            }
        }
    }
}