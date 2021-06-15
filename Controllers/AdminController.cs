using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparePartsShop.Models;
using SparePartsShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Controllers
{
    public class AdminController : Controller
    {

        private OrdersRepository _ordersRepository;
        private ProductsRepository _productsRepository;

        public AdminController(OrdersRepository ordersRepository,ProductsRepository productsRepository)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
        }

        public IActionResult Index()=>
            View(_ordersRepository.GetOrders());
        
        public RedirectToActionResult DeleteOrder(int id)
        {
            _ordersRepository.DeleteOrder(id);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult DeleteDetails(int id)
        {
            _ordersRepository.GetOrderDetails(id);
            return RedirectToAction("Details");
        }
        public RedirectToActionResult DeleteProduct(int id)
        {
            _productsRepository.Delete(id);
            return RedirectToAction("ProductsList");
        }
        public IActionResult CreateProduct()
        {
            ViewBag.BrandId = _productsRepository.GetBrandsDict().Select(r => new SelectListItem(r.Value,r.Key.ToString()));
            ViewBag.CategoryId = _productsRepository.GetCategoriesDict().Select(r => new SelectListItem(r.Value, r.Key.ToString()));
            return View("ProductForm", new Product());
        }
        [HttpPost]
        public RedirectToActionResult ProcessCreate(Product product)
        {
            Product prod = _productsRepository.GetProduct(product);

            if (prod is not null)
            {
                prod.BrandId = product.BrandId;
                prod.CarBody = product.CarBody;
                prod.CategoryId = product.CategoryId;
                prod.Cost = prod.Cost;
                prod.EngineCapacity = product.EngineCapacity;
                prod.FuelType = product.FuelType;
                prod.Img = product.Img;
                prod.ProductionYear = product.ProductionYear;
                prod.Model = product.Model;
                _productsRepository.Save();
            }
            else
            {
                _productsRepository.Add(product);
            }
            
            return RedirectToAction("ProductsList");
        }
        public IActionResult Edit(int id)
        {
            Product product = _productsRepository.GetProducts().SingleOrDefault(x => x.Id == id);
            ViewBag.BrandId = _productsRepository.GetBrandsDict().Select(r => new SelectListItem(r.Value, r.Key.ToString()));
            ViewBag.CategoryId = _productsRepository.GetCategoriesDict().Select(r => new SelectListItem(r.Value, r.Key.ToString()));
            return View("ProductForm", product);
        }
        public IActionResult Details(int id)
        {
            var item = _ordersRepository.GetOrder(id);
            List<OrderDetails> itemOrders = _ordersRepository.GetOrderDetails(id);
            Tuple<Order, List<OrderDetails>> info = new(item, itemOrders);
            return View(info);
        }
        public IActionResult ProductsList()
        {
            Tuple<IEnumerable<Product>, Dictionary<int, string>, Dictionary<int, string>> info = new(_productsRepository.GetProducts(), _productsRepository.GetBrandsDict(), _productsRepository.GetCategoriesDict());
            return View(info);
        }
        [HttpPost]
        public IActionResult Save(Order order)
        {
            Order oldOrder = _ordersRepository.GetOrder(order.Id);

            oldOrder.Name = order.Name;
            oldOrder.SurName = order.SurName;
            oldOrder.Phone = order.Phone;
            oldOrder.Adress = order.Adress;
            oldOrder.Email = order.Email;
            _ordersRepository.Save();
            return View("Index", _ordersRepository.GetOrders());
        }


    }
}
