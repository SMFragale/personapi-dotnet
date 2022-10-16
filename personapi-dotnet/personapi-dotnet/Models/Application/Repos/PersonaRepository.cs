using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public class PersonaRepository : Repository, IPersonaRepository
    {
        public PersonaRepository(persona_dbContext context) : base(context)
        {
        }

        public async Task<Persona> CreatePersona(Persona persona)
        {
            await _context.Set<Persona>().AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> DeletePersona(Persona persona)
        {
            if (persona is null)
                return false;
            _context.Set<Persona>().Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }

        public Persona GetPersona(int ccPersona)
        {
            return _context.Personas.Find(ccPersona);
        }

        public async Task<bool> UpdatePersona(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
