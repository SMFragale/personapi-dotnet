using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public class TelefonoRepository : Repository, ITelefonoRepository
    {
        public TelefonoRepository(persona_dbContext context) : base(context)
        {
        }

        public async Task<Telefono> CreateTelefono(Telefono telefono)
        {
            await _context.Set<Telefono>().AddAsync(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<bool> DeleteTelefono(Telefono telefono)
        {
            if (telefono is null)
                return false;
            _context.Set<Telefono>().Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }

        public Telefono GetTelefono(string num, int idDuenio)
        {
            return _context.Telefonos.Find(num, idDuenio);
        }

        public async Task<bool> UpdateTelefono(Telefono telefono)
        {
            _context.Entry(telefono).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
