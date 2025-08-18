using Model;

using System.Collections.Generic;

namespace AccessManager.Core.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
    }
}
