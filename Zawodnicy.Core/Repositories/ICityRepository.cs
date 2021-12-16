using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> BrowseAllAsync();
        Task<City> GetAsync(int id);
        Task DelAsync(City city);
        Task UpdateAsync(City city);
        Task AddAsync(City city);
    }
}
