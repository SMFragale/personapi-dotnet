using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Application.Repos;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoController
    {

        private ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetTelefono))]
        public ActionResult<Telefono> GetTelefono(string num, int idDuenio)
        {
            var telefonoById = _telefonoRepository.GetTelefono(num, idDuenio);
            if (telefonoById == null)
                return new NotFoundResult();
            return telefonoById;
        }

        [HttpPost]
        [ActionName(nameof(CreateTelefono))]
        public async Task<ActionResult<Telefono>> CreateTelefono(Telefono telefono)
        {
            await _telefonoRepository.CreateTelefono(telefono);
            return new CreatedResult("Telefono", telefono);
        }

        [HttpPut("{num}/{idDuenio}")]
        [ActionName(nameof(UpdateTelefono))]
        public async Task<ActionResult> UpdateTelefono(string num, int idDuenio, Telefono telefono)
        {
            if (num != telefono.Num && idDuenio != telefono.Duenio)
                return new BadRequestResult();

            await _telefonoRepository.UpdateTelefono(telefono);

            return new NoContentResult();
        }

        [HttpDelete("{num}/{idDuenio}")]
        [ActionName(nameof(DeleteTelefono))]
        public async Task<IActionResult> DeleteTelefono(string num, int idDuenio)
        {
            var telefono = _telefonoRepository.GetTelefono(num, idDuenio);
            if (telefono == null)
            {
                return new NotFoundResult();
            }

            await _telefonoRepository.DeleteTelefono(telefono);

            return new NoContentResult();
        }

    }
}
