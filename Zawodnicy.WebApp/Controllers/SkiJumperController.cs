using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Zawodnicy.WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zawodnicy.WebApp.Controllers
{
    public class SkiJumperController : Controller
    {
        public IConfiguration Configuration;

        public SkiJumperController(IConfiguration c)
        {
            Configuration = c;
        }


        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private String CN()
        {
            string cn = ControllerContext.RouteData.Values["controller"].ToString();
            return cn;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //odwołanie do api
            string _restpath = GetHostUrl().Content + CN();
            List<SkiJumperVM> skiJumperList = new List<SkiJumperVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    skiJumperList = JsonConvert.DeserializeObject<List<SkiJumperVM>>(apiResponse);
                }
            }

            return View(skiJumperList);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            SkiJumperVM s = new SkiJumperVM();


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                }
            }

            return View(s);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(SkiJumperVM s)
        {
            string _restpath = GetHostUrl().Content + CN();
            SkiJumperVM result = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    String jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{_restpath}/{s.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => { return View(new CreateSkiJumperVM()); });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateSkiJumperVM s)
        {
            string _restpath = GetHostUrl().Content + CN();
            SkiJumperVM result = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    String jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            SkiJumperVM result = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }
    }
}