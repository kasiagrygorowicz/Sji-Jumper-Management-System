using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zawodnicy.WebApp.Controllers
{
    public class AdminController : Controller
    {
     
            [Authorize(Roles="zarzadca")]
            // GET
            public async Task<IActionResult> Index()
            {
                return await Task.Run(()=>View());
            }
        }
}