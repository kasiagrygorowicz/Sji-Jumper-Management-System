using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumpRepository
    {
        Task<IEnumerable<SkiJump>> BrowseAllAsync();
        Task<SkiJump> GetAsync(int id);
        Task DelAsync(SkiJump skiJump);
        Task UpdateAsync(SkiJump skiJump);
        Task AddAsync(SkiJump skiJump);
    }
}
