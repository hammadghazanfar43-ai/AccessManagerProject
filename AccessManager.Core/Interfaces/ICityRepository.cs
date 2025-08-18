using Model;

using System.Collections.Generic;

namespace AccessManager.Core.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetByCountryId(int countryId);
    }
}
