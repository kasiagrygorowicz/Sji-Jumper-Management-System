using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.services
{
    public interface ITrainerService
    {

        Task<IEnumerable<TrainerDTO>> BrowseAll();
        Task<TrainerDTO> FindById(int id);
        Task AddAsync(CreateTrainer newTrainer);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateTrainer updatedTrainer, int id);
        Task<IEnumerable<TrainerDTO>> BrowseAllByFilterAsync(string lastname);
    }
}
