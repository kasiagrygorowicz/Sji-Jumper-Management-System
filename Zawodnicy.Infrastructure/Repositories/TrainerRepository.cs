using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {

        private AppDbContext _appDbContext;

        public TrainerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Trainer t)
        {
            try
            {
                _appDbContext.Trainer.Add(t);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;

            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<IEnumerable<Trainer>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Trainer);
        }

        public async Task<IEnumerable<Trainer>> BrowseAllByFilterAsync(string lastname)
        {
            return await Task.FromResult(_appDbContext.Trainer.Where(t => t.Lastname.Contains(lastname)).AsEnumerable());
        }

        public async Task DelAsync(Trainer trainer)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Trainer.FirstOrDefault(x => x.Id == trainer.Id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;

            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Trainer> GetAsync(int id)
        {

            return await Task.FromResult(_appDbContext.Trainer.FirstOrDefault(t => t.Id == id));
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            try
            {
                var z = _appDbContext.Trainer.FirstOrDefault(x => x.Id == trainer.Id);

                z.Name = trainer.Name;
                z.Lastname = trainer.Lastname;
                z.Birthday = trainer.Birthday;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;

            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }

        }
    }
}
