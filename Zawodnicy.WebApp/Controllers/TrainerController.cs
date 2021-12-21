using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Zawodnicy.WebApp.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Zawodnicy.WebApp.Controllers
{
    public class TrainerController : Controller
    {
        
        public IConfiguration Configuration;

        public TrainerController(IConfiguration c)
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
        
        
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tokenString = GenerateJsonWebToken();
            string _restpath = GetHostUrl().Content + CN();
            List<TrainerVM> trainerList = new List<TrainerVM>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    trainerList = JsonConvert.DeserializeObject<List<TrainerVM>>(apiResponse);
                }
            }

            return View(trainerList);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => { return View(new CreateTrainerVM()); });
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTrainerVM t)
        {
            string _restpath = GetHostUrl().Content + CN();
            TrainerVM result = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    String jsonString = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
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
            TrainerVM  result = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
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
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            TrainerVM t = new TrainerVM();


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                }
            }

            return View(t);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(UpdateTrainerVM s)
        {
            string _restpath = GetHostUrl().Content + CN();
            TrainerVM result = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    String jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{_restpath}/{s.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }


            return RedirectToAction(nameof(Index));
        }

        private string GenerateJsonWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperTajneHaslo111222"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Name", "Kasia"),
                new Claim(JwtRegisteredClaimNames.Email, "01153047@pw.edu.pl")
            };

            var token = new JwtSecurityToken(
                issuer: "https//localhost:5001",
                audience: "https://localhost:55855",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}