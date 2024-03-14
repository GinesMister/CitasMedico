using CitasMedico.DTOs;
using CitasMedico.Exceptions;
using CitasMedico.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedico.Controllers
{
    [Route("citasmedicos/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly PacienteService _service;

        public PacienteController(PacienteService service)
        {
            _service = service;
        }

        // GET: citasmedicos/Paciente
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MedicoDTO>))]
        public IActionResult GetAllMedicos()
        {
            return Ok(_service.GetAllPacientes());
        }

        // GET: citasmedicos/Paciente/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PacienteDTO))]
        [ProducesResponseType(404)]
        public IActionResult GetPacienteById(int id)
        {
            try
            {
                var response = _service.GetPacienteById(id);
                return Ok(response);
            }
            catch (ServiceException ex)
            {
                if (ex.Error == ErrorType.NotFound)
                {
                    ModelState.AddModelError("", ex.Message);
                    return NotFound(ModelState);
                }
            }
            return BadRequest();
        }

        // PUT: citasmedicos/Paciente/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePaciente(int id, [FromBody] PacienteRequestDTO paciente)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = _service.UpdatePaciente(id, paciente);
                return Ok(result);
            }
            catch (ServiceException ex)
            {
                ModelState.AddModelError("", ex.Message);
                switch (ex.Error)
                {
                    case ErrorType.NotFound:
                        return NotFound(ModelState);
                    case ErrorType.UnexpectedError:
                        return Problem(ex.Message, statusCode: 500);
                    default:
                        return BadRequest(ModelState);
                }
            }
        }

        // POST: citasmedicos/Pacientes
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreatePaciente([FromBody] PacienteRequestDTO paciente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.CreatePaciente(paciente);
                return Created("", result);
            }
            catch (ServiceException ex)
            {
                ModelState.AddModelError("", ex.Message);
                switch (ex.Error)
                {
                    case ErrorType.UnexpectedError:
                        return Problem(ex.Message, statusCode: 500);
                }
                return BadRequest(ModelState);
            }
        }

        // DELETE: citasmedicos/Medico/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePacienteById(int id)
        {
            try
            {
                _service.DeletePacienteById(id);
                return NoContent();
            }
            catch (ServiceException ex)
            {
                switch (ex.Error)
                {
                    case ErrorType.NotFound:
                        return NotFound();
                    default:
                        ModelState.AddModelError("", ex.Message);
                        return BadRequest(ModelState);
                }
            }
        }
    }
}
