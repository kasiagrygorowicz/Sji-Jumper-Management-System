using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zawodnicy.Core.Domain;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;
        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _trainerService.BrowseAll();
            return Json(z);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainer(int id)
        {

            var z = await _trainerService.FindById(id);
            return Json(z);
        }


        [HttpPost]
        public async Task<IActionResult> AddTrainer([FromBody] CreateTrainer trainer)
        {
            await _trainerService.AddAsync(trainer);
            return Created("", trainer);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer([FromBody] UpdateTrainer trainer, int id)
        {
            await _trainerService.UpdateAsync(trainer, id);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            await _trainerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<IActionResult>  BrowseByLastname(string lastname)
        {
            IEnumerable<TrainerDTO> t = await _trainerService.BrowseAllByFilterAsync(lastname);
            return Json(t);
        }




    }
}
