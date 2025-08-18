using System.Collections.Generic;
using System.Linq;
using AccessManager.Core.Interfaces;
using Model;

using AccessManager.Core.Data; // ✅ to access AppDbContext

namespace AccessManager.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context; // ✅ use AppDbContext here

        public CountryRepository(AppDbContext context) // ✅ update constructor
        {
            _context = context;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }
    }
}
