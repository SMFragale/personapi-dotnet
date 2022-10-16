using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public interface IEstudioRepository
    {
        Task<Estudio> CreateEstudio(Estudio estudio);
        Task<bool> DeleteEstudio(Estudio estudio);
        Estudio GetEstudio(int ccPersona, int idProf);
        Task<bool> UpdateEstudio(Estudio estudio);
    }
}
