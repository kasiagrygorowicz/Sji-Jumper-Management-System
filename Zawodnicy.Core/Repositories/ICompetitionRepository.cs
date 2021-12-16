using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Infrastructure;

namespace Zawodnicy.Core.Repositories
{
    public interface ICompetitionRepository
    {
        Task<IEnumerable<Competition>> BrowseAllAsync();
        Task<Competition> GetAsync(int id);
        Task DelAsync(Competition competition);
        Task UpdateAsync(Competition competition);
        Task AddAsync(Competition competition);
    }
}
