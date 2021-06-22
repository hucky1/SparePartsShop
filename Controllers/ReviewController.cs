using Microsoft.AspNetCore.Mvc;
using SparePartsShop.Models;
using SparePartsShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Controllers
{
    public class ReviewController : Controller
    {
        ReviewsRepository _reviewsRepository;

        public ReviewController(ReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult Create(Reviews reviews)
        {
            _reviewsRepository.Add(reviews);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
