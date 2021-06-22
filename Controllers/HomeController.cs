using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SparePartsShop.Models;
using SparePartsShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ReviewsRepository _reviewsRepository;


        public HomeController(ILogger<HomeController> logger,ReviewsRepository reviewsRepository)
        {
            _logger = logger;
            _reviewsRepository = reviewsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult About()
        {
            return View(_reviewsRepository.GetReviews());
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
