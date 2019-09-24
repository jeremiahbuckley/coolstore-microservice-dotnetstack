using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatalogService.Models;

namespace CatalogService.Controllers
{
    [Route("/products")]
    public class CatalogController : Controller
    {
        private ICatalogSvc catalogService;

        public CatalogController(ICatalogSvc catalogService)
        {
            this.catalogService = catalogService;
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            return Ok(catalogService.GetProducts());
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            catalogService.Add(product);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
