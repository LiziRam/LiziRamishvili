using Mapster;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;
using PersonManagement.Web.Infrastructure.Localizations;
using PersonManagement.Web.Models;
using PersonManagement.Web.Models.DTO;

namespace PersonManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<PersonDTO>> GetAll()
        {
            var result = await _service.GetAllAsync();

            return result.Adapt<List<PersonDTO>>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(ErrorMessages.NotFound);

            var personDTOResult = result.Adapt<PersonDTO>();

            return Ok(personDTOResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.DeleteAsync(id))
                return Ok();

            return NotFound(ErrorMessages.NotFound);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonRequest createRequest)
        {
            var person = createRequest.Adapt<PersonServiceModel>();

            var newId = await _service.CreateAsync(person);
            return Ok(newId);
        }
    }
}
