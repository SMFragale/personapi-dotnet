using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public class EstudioRepository : Repository, IEstudioRepository
    {
        public EstudioRepository(persona_dbContext context) : base(context)
        {
        }

        public async Task<Estudio> CreateEstudio(Estudio estudio)
        {
            await _context.Set<Estudio>().AddAsync(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task<bool> DeleteEstudio(Estudio estudio)
        {
            if (estudio is null)
                return false;
            _context.Set<Estudio>().Remove(estudio);
            await _context.SaveChangesAsync();
            return true;
        }

        public Estudio GetEstudio(int ccPersona, int idProf)
        {
            return _context.Estudios.Find(ccPersona, idProf);
        }

        public async Task<bool> UpdateEstudio(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
