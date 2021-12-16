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
    public class TrainerService : ITrainerService
    {

        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task AddAsync(CreateTrainer newTrainer)
        {
            Trainer trainer = new Trainer()
            {
                Name = newTrainer.Name,
                Lastname = newTrainer.Lastname,

            };

            await Task.Run(() =>
            {
                _trainerRepository.AddAsync(trainer);
            });
        }

        public async Task<IEnumerable<TrainerDTO>> BrowseAll()
        {
            var z = await _trainerRepository.BrowseAllAsync();

            return z.Select(x => ConvertTrainerToDTO(x));
        }

        public async Task<IEnumerable<TrainerDTO>> BrowseAllByFilterAsync(string lastname)
        {
            var z = await _trainerRepository.BrowseAllByFilterAsync(lastname);
            return z.Select(t => ConvertTrainerToDTO(t));
        }

        public async Task DeleteAsync(int id)
        {
            Trainer t = await _trainerRepository.GetAsync(id);
            await _trainerRepository.DelAsync(t);
        }

        public async Task<TrainerDTO> FindById(int id)
        {
            return ConvertTrainerToDTO(await _trainerRepository.GetAsync(id));
        }

        public async Task UpdateAsync(UpdateTrainer updatedTrainer, int id)
        {
            await _trainerRepository.UpdateAsync(ConvertUpdateTrainerToTrainer(updatedTrainer, id));
        }

        protected TrainerDTO ConvertTrainerToDTO(Trainer t)
        {
            return new TrainerDTO()
            {
                Id = t.Id,
                Name = t.Name,
                Lastname = t.Lastname,
                Birthday = t.Birthday
            };
        }

        protected Trainer ConvertUpdateTrainerToTrainer(UpdateTrainer t, int id)


        {

            return new Trainer()
            {
                Id = id,
                Name = t.Name,
                Lastname = t.Lastname,
                Birthday = t.Birthday
            };

        }


    }
}
