using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Models;

namespace ReviewService.Controllers
{
    [Route("review")]
    public class ReviewController : Controller
    {   
        private readonly IReviewSvc reviewService;

        public ReviewController(IReviewSvc reviewService)
        {
            this.reviewService = reviewService;
        }


        [HttpGet("{itemId}")]
        public IActionResult Index(string itemId)
        {
            IList<Review> result = reviewService.getReviews(itemId);
            return Ok(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
