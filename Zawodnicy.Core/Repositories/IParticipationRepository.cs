using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface IParticipationRepository
    {
        Task<IEnumerable<Participation>> BrowseAllAsync();
        Task<Participation> GetAsync(int id);
        Task DelAsync(Participation participation);
        Task UpdateAsync(Participation participation);
        Task AddAsync(Participation participation);
    }
}
