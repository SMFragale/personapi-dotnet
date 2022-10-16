using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Application.Repos;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController
    {

        private IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetPersona))]
        public ActionResult<Persona> GetPersona(int cc)
        {
            var personaById = _personaRepository.GetPersona(cc);
            if (personaById == null)
                return new NotFoundResult();
            return personaById;
        }

        [HttpPost]
        [ActionName(nameof(CreatePersona))]
        public async Task<ActionResult<Persona>> CreatePersona(Persona persona)
        {
            await _personaRepository.CreatePersona(persona);
            return new CreatedResult("Persona", persona);
        }

        [HttpPut("{cc}")]
        [ActionName(nameof(UpdatePersona))]
        public async Task<ActionResult> UpdatePersona(int cc, Persona persona)
        {
            if (cc != persona.Cc)
                return new BadRequestResult();

            await _personaRepository.UpdatePersona(persona);

            return new NoContentResult();
        }

        [HttpDelete("{cc}")]
        [ActionName(nameof(DeletePersona))]
        public async Task<IActionResult> DeletePersona(int cc)
        {
            var persona = _personaRepository.GetPersona(cc);
            if (persona == null)
            {
                return new NotFoundResult();
            }

            await _personaRepository.DeletePersona(persona);

            return new NoContentResult();
        }

    }
}
