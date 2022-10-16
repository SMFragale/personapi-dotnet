using personapi_dotnet.Models.Entities;


namespace personapi_dotnet.Models.Application.Repos
{
    public interface ITelefonoRepository
    {
        
        Task<Telefono> CreateTelefono(Telefono telefono);
        Task<bool> DeleteTelefono(Telefono telefono);
        Telefono GetTelefono(string num, int idDuenio);
        Task<bool> UpdateTelefono(Telefono telefono);
    }
}