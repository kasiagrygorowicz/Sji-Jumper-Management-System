using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class SkiJumperRepository : ISkiJumperRepository
    {
        public static List<SkiJumper> _skiJumperMock = new List<SkiJumper>();
        private AppDbContext _appDbContext;


        public SkiJumperRepository(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
          
        }
        public async Task AddAsync(SkiJumper s)
        {
            try
            {
                _appDbContext.SkiJumper.Add(s);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;

            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }

        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.SkiJumper);
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country, string name)
        {
            var s = _appDbContext.SkiJumper.Where(x => x.Country.Contains(country) || x.Name.Contains(name)).AsEnumerable();
            return await Task.FromResult(s);
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country)
        {
            var s = _appDbContext.SkiJumper.Where(x => x.Country.Contains(country)).AsEnumerable();
            return await Task.FromResult(s);
        }

        public async Task DelAsync(SkiJumper s)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.SkiJumper.FirstOrDefault(x => x.Id == s.Id));
                _appDbContext.SaveChanges();
                ;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            } }

        public async Task<SkiJumper> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.SkiJumper.FirstOrDefault(t => t.Id == id));

        }

        public async Task UpdateAsync(SkiJumper s)
        {

            try
            {
                var z = _appDbContext.SkiJumper.FirstOrDefault(x => x.Id == s.Id);

                z.Name = s.Name;
                z.ForeName = s.ForeName;
                z.DateTime = s.DateTime;
                z.Weight = s.Weight;
                z.Height = s.Height;
                z.Country = s.Country;

                _appDbContext.SaveChanges();

            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }




        }
    }
}