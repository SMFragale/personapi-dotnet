using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Application.Repos
{
    public class Repository
    {
        protected readonly persona_dbContext _context;
        public Repository(persona_dbContext context)
        {
            _context = context;
        }
    }
}
