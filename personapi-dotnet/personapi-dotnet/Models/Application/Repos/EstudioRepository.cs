using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public class EstudioRepository : Repository, IEstudioRepository
    {
        public EstudioRepository(persona_dbContext context) : base(context)
        {
        }

        public Task<Estudio> CreateEstudio(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEstudio(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio GetEstudio(int ccPersona, int idProf)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEstudio(Estudio estudio)
        {
            throw new NotImplementedException();
        }
    }
}
