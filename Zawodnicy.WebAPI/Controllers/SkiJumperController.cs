using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class SkiJumperController : Controller
    {

        private readonly ISkiJumperService _skiJumperService;

        public SkiJumperController(ISkiJumperService skiJumperService)
        {
            _skiJumperService = skiJumperService;
        }

        //skijumper

        [HttpGet]
      
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _skiJumperService.BrowseAll();
            return Json(z);
        }

        //skijumper/{id }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetSkiJumper(int id)
        {

            var z = await _skiJumperService.FindById(id);
            return Json(z);
        }

        //skijumper/filter?country=pol&name=jan
        [HttpGet("filter")]
        public async Task<IActionResult> GetSkiJumper(string country, string name =null)
        {
            return Json(await _skiJumperService.BrowseAllByFilterAsync(country,name));
        }

        //skijumper
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddSkiJumper([FromBody] CreateSkiJumper skiJumper)
        {
            await _skiJumperService.AddAsync(skiJumper);
            return Created("", skiJumper);

        }

        //skijumper/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateSkiJumper([FromBody] UpdateSkiJumper skiJumper, int id)
        {
            await _skiJumperService.UpdateAsync(skiJumper, id);
            return NoContent();

        }

        //skijumper/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSkiJumper(int id)
        {
            await _skiJumperService.DeleteAsync(id);
            return NoContent();
        }
    }
}
