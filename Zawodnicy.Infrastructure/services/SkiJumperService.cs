using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.services
{
    public class SkiJumperService : ISkiJumperService
    {
        private readonly ISkiJumperRepository _skiJumperRepository;

        public SkiJumperService(ISkiJumperRepository skiJumperRepository)
        {
            _skiJumperRepository = skiJumperRepository;
        }

        public async Task AddAsync(CreateSkiJumper newSkiJumper)
        {
            SkiJumper s = new SkiJumper()
            {
                Name = newSkiJumper.Name,
                ForeName = newSkiJumper.ForeName,
                Country = newSkiJumper.Country

            };

            await Task.Run(() =>
            {
                _skiJumperRepository.AddAsync(s);
            });
           
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAll()
        {
            var z = await _skiJumperRepository.BrowseAllAsync();

            return z.Select(x => ConvertSkiJumperToDTO(x));
        }

        public async  Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country, string name)
        {
   
                var z = await _skiJumperRepository.BrowseAllByFilterAsync(country, name);
            return z.Select(x => ConvertSkiJumperToDTO(x));
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country)
        {
            var z = await _skiJumperRepository.BrowseAllByFilterAsync(country);
            return z.Select(x => ConvertSkiJumperToDTO(x));
        }

        public async Task DeleteAsync(int id)
        {
            SkiJumper s = await _skiJumperRepository.GetAsync(id);
            await _skiJumperRepository.DelAsync(s);
        }

        public async Task<SkiJumperDTO> FindById(int id)
        {
            return  ConvertSkiJumperToDTO(await _skiJumperRepository.GetAsync(id));
            
        }

        public async Task UpdateAsync(UpdateSkiJumper skiJumper, int id)
        {
             
                await _skiJumperRepository.UpdateAsync(ConvertUpdateSkiJumperToSkiJumper(skiJumper,id));
            
        }

        protected SkiJumperDTO ConvertSkiJumperToDTO(SkiJumper s)
        {
            return new SkiJumperDTO()
            {
                Id = s.Id,
                Country = s.Country,
                Name = s.Name,
                DateTime = s.DateTime,
                ForeName = s.ForeName,
                Weight = s.Weight,
                Height = s.Height

            };
        }

        protected SkiJumper ConvertUpdateSkiJumperToSkiJumper(UpdateSkiJumper s,int id)
        {
            return new SkiJumper()
            {
                Id=id,
                Name = s.Name,
                ForeName = s.ForeName,
                Country = s.Country

            };
        }
    }

}










