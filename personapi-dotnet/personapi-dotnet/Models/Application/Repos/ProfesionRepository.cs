using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public class ProfesionRepository: IProfesionRepository
    {
        protected readonly persona_dbContext _context;
        public ProfesionRepository(persona_dbContext context)
        {
            _context = context;
        }

        public async Task<Profesion> CreateProfesion(Profesion profesion)
        {
            await _context.Set<Profesion>().AddAsync(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<bool> DeleteProfesion(Profesion profesion)
        {
            if (profesion is null)
                return false;
            _context.Set<Profesion>().Remove(profesion);
            await _context.SaveChangesAsync();
            return true;
        }

        public Profesion GetProfesion(int idProfesion)
        {
            return _context.Profesions.Find(idProfesion);
        }

        public async Task<bool> UpdateProfesion(Profesion profesion)
        {
            _context.Entry(profesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
