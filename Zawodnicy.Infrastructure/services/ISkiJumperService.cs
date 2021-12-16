using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.services
{
    public interface ISkiJumperService
    {
        Task<IEnumerable<SkiJumperDTO>> BrowseAll();
        Task<SkiJumperDTO> FindById (int id);
        Task AddAsync(CreateSkiJumper newSkiJumper);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateSkiJumper skiJumper, int id);
        Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country, string name);
        Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country);



    }
}
