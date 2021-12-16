using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class CompetitionRepository : ICompetitionRepository

    {
        public CompetitionRepository()
        {
        }

        public Task AddAsync(Competition competition)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Competition>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Competition competition)
        {
            throw new NotImplementedException();
        }

        public Task<Competition> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Competition competition)
        {
            throw new NotImplementedException();
        }
    }
}
