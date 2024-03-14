using CitasMedico.DTOs;
using CitasMedico.Exceptions;
using CitasMedico.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedico.Controllers
{
    [Route("citasmedicos/[controller]")]
    [ApiController]
    public class MedicoController : Controller
    {
        private readonly MedicoService _service;

        public MedicoController(MedicoService service)
        {
            _service = service;
        }

        // GET: citasmedicos/Medicos
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MedicoDTO>))]
        public IActionResult GetAllMedicos()
        {
            return Ok(_service.GetAllMedicos());
        }

        // GET: citasmedicos/Medicos/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(MedicoDTO))]
        [ProducesResponseType(404)]
        public IActionResult GetMedicoById(int id)
        {
            try
            {
                var response = _service.GetMedicoById(id);
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

        // PUT: citasmedicos/Medicos/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMedico(int id, [FromBody] MedicoRequestDTO medico)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = _service.UpdateMedico(id, medico);
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

        // POST: citasmedicos/Medicos
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateMedico([FromBody] MedicoRequestDTO medico)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.CreateMedico(medico);
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
        public IActionResult DeleteMedicoById(int id)
        {
            try
            {
                _service.DeleteMedicoById(id);
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
