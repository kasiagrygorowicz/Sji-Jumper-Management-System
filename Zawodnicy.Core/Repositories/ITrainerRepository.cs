using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITrainerRepository
    {
        Task<IEnumerable<Trainer>> BrowseAllAsync();
        Task<Trainer> GetAsync(int id);
        Task DelAsync(Trainer trainer);
        Task UpdateAsync(Trainer trainer);
        Task AddAsync(Trainer trainer);
        Task<IEnumerable<Trainer>> BrowseAllByFilterAsync(string lastname);
    }
}
