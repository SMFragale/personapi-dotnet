using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Application.Repos;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController
    {

        private IEstudioRepository _estudioRepository;

        public EstudioController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEstudio))]
        public ActionResult<Estudio> GetEstudio(int ccPersona, int idProf)
        {
            var estudioById = _estudioRepository.GetEstudio(ccPersona,idProf);
            if (estudioById == null)
                return new NotFoundResult();
            return estudioById;
        }

        [HttpPost]
        [ActionName(nameof(CreateEstudio))]
        public async Task<ActionResult<Estudio>> CreateEstudio(Estudio estudio)
        {
            await _estudioRepository.CreateEstudio(estudio);
            return new CreatedResult("Estudio", estudio);
        }

        [HttpPut("{ccPersona}/{idProf}")]
        [ActionName(nameof(UpdateEstudio))]
        public async Task<ActionResult> UpdateEstudio(int ccPersona, int idProf, Estudio estudio)
        {
            if (ccPersona != estudio.CcPer && idProf != estudio.IdProf)
                return new BadRequestResult();

            await _estudioRepository.UpdateEstudio(estudio);

            return new NoContentResult();
        }

        [HttpDelete("{ccPersona}/{idProf}")]
        [ActionName(nameof(DeleteEstudio))]
        public async Task<IActionResult> DeleteEstudio(int ccPersona, int idProf)
        {
            var estudio = _estudioRepository.GetEstudio(ccPersona,idProf);
            if (estudio == null)
            {
                return new NotFoundResult();
            }

            await _estudioRepository.DeleteEstudio(estudio);

            return new NoContentResult();
        }

    }
}
