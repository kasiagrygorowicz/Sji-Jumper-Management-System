using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class SkiJumpRepository : ISkiJumpRepository
    {
        public SkiJumpRepository()
        {
        }

        public Task AddAsync(SkiJump skiJump)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SkiJump>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(SkiJump skiJump)
        {
            throw new NotImplementedException();
        }

        public Task<SkiJump> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SkiJump skiJump)
        {
            throw new NotImplementedException();
        }
    }
}
