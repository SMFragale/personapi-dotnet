using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Application.Repos;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController
    {

        private IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetProfesion))]
        public ActionResult<Profesion> GetProfesion(int id)
        {
            var profesionById = _profesionRepository.GetProfesion(id);
            if (profesionById == null)
                return new NotFoundResult();
            return profesionById;
        }

        [HttpPost]
        [ActionName(nameof(CreateProfesion))]
        public async Task<ActionResult<Profesion>> CreateProfesion(Profesion profesion)
        {
            await _profesionRepository.CreateProfesion(profesion);
            return new CreatedResult("Profesion", profesion);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateProfesion))]
        public async Task<ActionResult> UpdateProfesion(int id, Profesion profesion)
        {
            if (id != profesion.Id)
                return new BadRequestResult();

            await _profesionRepository.UpdateProfesion(profesion);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteProfesion))]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesion = _profesionRepository.GetProfesion(id);
            if (profesion == null)
            {
                return new NotFoundResult();
            }

            await _profesionRepository.DeleteProfesion(profesion);

            return new NoContentResult();
        }

    }
}
