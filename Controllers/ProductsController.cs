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

        //private readonly ArticlesRepository articlesRepository;
        //public ArticlesController(ArticlesRepository articlesRepository)
        //{
        //    this.articlesRepository = articlesRepository;
        //}
        public ProductsController(ProductsRepository repository)
        {
            products = repository;
        }
        public RedirectToActionResult ResetSearchresults()
        {
            //CurrentProducts = products.GetProducts();

            return RedirectToAction("List");
        }
       
       //public IActionResult FindByCategory(int categoryId)
       //{
       //     //CurrentProducts = products.GetByCategory(categoryId);
       //     Tuple<IEnumerable<Product>, Dictionary<int, string>, Dictionary<int, string>> info = new(products.GetByCategory(categoryId), products.GetBrandsDict(), products.GetCategoriesDict());
       //     return View("List",info);
       // }
       
       // public IActionResult FindByBrand(int brandId)
       // {
       //     Tuple<IEnumerable<Product>, Dictionary<int, string>, Dictionary<int, string>> info = new(products.GetByBrand(brandId), products.GetBrandsDict(), products.GetCategoriesDict());
       //     return View("List", info);
       // }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List()
        {
            // products.Initial();

            Tuple<IEnumerable<Product>, Dictionary<int,string>, Dictionary<int, string>> info = new(products.GetProducts(), products.GetBrandsDict(),products.GetCategoriesDict());
         return View(info);
        }
    }
}
