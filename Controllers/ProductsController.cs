using Microsoft.AspNetCore.Mvc;
using SparePartsShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IBrand _brand;
        private readonly IProductsCategory _productsCategory;

        public ProductsController(IAllProducts allProducts, IBrand brand, IProductsCategory productsCategory)
        {
            _allProducts = allProducts;
            _brand = brand;
            _productsCategory = productsCategory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List()
        {
            return View(_allProducts.GetAll);
        }
    }
}
