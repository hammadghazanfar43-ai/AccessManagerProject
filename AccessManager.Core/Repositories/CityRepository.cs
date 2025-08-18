using AccessManager.Core.Interfaces;
using Model;

using AccessManager.Core.Data; // ✅ Correct namespace
using System.Collections.Generic;
using System.Linq;

namespace AccessManager.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetByCountryId(int countryId)
        {
            return _context.Cities
                           .Where(c => c.CountryId == countryId)
                           .ToList();
        }
    }
}
