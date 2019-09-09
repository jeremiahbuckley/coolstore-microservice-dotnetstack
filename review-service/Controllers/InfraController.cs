using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Models;

namespace ReviewService.Controllers
{
    [Route("infra")]
    public class InfraController : Controller
    {   
        [HttpGet("health")]
        public IActionResult Index()
        {
            return StatusCode(500, "TODO: return infra health");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
