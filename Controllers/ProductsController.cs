using Microsoft.AspNetCore.Mvc;
using SparePartsShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SparePartsShop.Services.Data;
using SparePartsShop.Models;



namespace SparePartsShop.Controllers
{
    
    public class ProductsController : Controller
    {
        private  ProductsRepository products;
        Dictionary<int, string> Brands;
         Dictionary<int, string> Categories;
        Dictionary<int, string> Fuels;

        //private readonly ArticlesRepository articlesRepository;
        //public ArticlesController(ArticlesRepository articlesRepository)
        //{
        //    this.articlesRepository = articlesRepository;
        //}
        public ProductsController(ProductsRepository repository)
        {
            products = repository;
            Brands = products.GetBrandsDict();
            Categories = products.GetCategoriesDict();
            Fuels = products.GetFuelsDict();
        }
        public RedirectToActionResult ResetSearchresults()
        {
            //CurrentProducts = products.GetProducts();

            return RedirectToAction("List");
        }

        public IActionResult FindByCategory(int categoryId)
        {
            var info = products.GetByCategory(categoryId);
            //CurrentProducts = products.GetByCategory(categoryId);
            ViewBag.Brands = Brands;
            ViewBag.Categories = Categories;
            return View("List", info);
        }

        public IActionResult FindByBrand(int brandId)
        {
            var info = products.GetByBrand(brandId);
            ViewBag.Brands =Brands;
            ViewBag.Categories = Categories;
            return View("List", info);
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List()
        {
            ViewBag.Brands = Brands;
            ViewBag.Categories = Categories;
           
            IEnumerable<Product> info = products.GetProducts();
         return View(info);
        }
    }
}
