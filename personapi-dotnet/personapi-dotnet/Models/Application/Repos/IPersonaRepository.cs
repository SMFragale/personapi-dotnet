using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public interface IPersonaRepository
    {
        Task<Persona> CreatePersona(Persona persona);
        Task<bool> DeletePersona(Persona persona);
        Persona GetPersona(int ccPersona);
        Task<bool> UpdatePersona(Persona persona);
    }
}
