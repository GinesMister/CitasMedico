using Microsoft.AspNetCore.Mvc;
using CitasMedico.Services;
using CitasMedico.DTOs;
using CitasMedico.Exceptions;

namespace CitasMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : Controller
    {
        private readonly CitaService _service;

        public CitaController(CitaService service)
        {
            _service = service;
        }

        // GET: api/Cita
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CitaDTO>))]
        public IActionResult GetAllCitas()
        {
            return Ok(_service.GetAllCitas());
        }

        // GET: api/Cita/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CitaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCitaById(int id)
        {
            try
            {
                var response = _service.GetCitaById(id);
                return Ok(response);
            }
            catch (ServiceException ex)
            {
                ModelState.AddModelError("", ex.Message);
                if (ex.Error == ErrorType.NotFound)
                    return NotFound(ModelState);
            }
            return BadRequest();
        }

        // PUT: api/Cita/5
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
                ModelState.AddModelError("", ex.Message);
                switch (ex.Error)
                {
                    case ErrorType.NotFound:
                        return NotFound(ModelState);
                    case ErrorType.BadRequest:
                        return BadRequest(ModelState);
                    default:
                        return BadRequest(ModelState);
                }
            }
        }

        // POST: api/Cita
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
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/Cita/5
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
                ModelState.AddModelError("", ex.Message);
                switch(ex.Error)
                {
                    case ErrorType.NotFound: 
                        return NotFound(ModelState);
                    default:
                        return BadRequest(ModelState);
                }
            }
        }
    }
}