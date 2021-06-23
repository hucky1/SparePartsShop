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
        private ClientsRepository _clientsRepository;
        private ReviewsRepository _reviewsRepository;

        public AdminController(OrdersRepository ordersRepository,ProductsRepository productsRepository, ClientsRepository clientsRepository,ReviewsRepository reviewsRepository)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
            _clientsRepository = clientsRepository;
            _reviewsRepository = reviewsRepository;
        }
      

        //public IActionResult Index() =>
        //    View("Login");

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Main(AdminLogin admin)
        {
            if (admin.Password == "adminHello")
            {
                
                var Clients = _clientsRepository.GetClients();
                var Orders = _ordersRepository.GetOrders();
                Tuple<IEnumerable<Client>, List<Order>> info = new(Clients, Orders);
                return View(info);
            }
            else
                return View("Error");
        }


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
            ViewBag.FuelId = _productsRepository.GetFuelsDict().Select(r => new SelectListItem(r.Value, r.Key.ToString()));
            return View("ProductForm", new Product());
        }
        [HttpPost]
        public RedirectToActionResult ProcessCreate(Product product)
        {
            Product prod = _productsRepository.GetProduct(product);
           


            if (prod is not null)
            {
                prod.BrandId = product.Brand.Id;
                prod.CategoryId = product.Category.Id;
                prod.FuelTypeId = product.FuelType.Id;
                prod.CarBody = product.CarBody;
                prod.Cost = product.Cost;
                prod.EngineCapacity = product.EngineCapacity;
                prod.Img = product.Img;
                prod.ProductionYear = product.ProductionYear;
                prod.Model = product.Model;
                _productsRepository.Save();
            }
            else
            {
                product.BrandId = product.Brand.Id;
                product.CategoryId = product.Category.Id;
                product.FuelTypeId = product.FuelType.Id;
                product.Brand = null;
                product.Category = null;
                product.FuelType = null;
                _productsRepository.Add(product);
            }
            
            return RedirectToAction("ProductsList");
        }
        public IActionResult Edit(int id)
        {
            Product product = _productsRepository.GetProducts().SingleOrDefault(x => x.Id == id);
            ViewBag.BrandId = _productsRepository.GetBrandsDict().Select(r => new SelectListItem(r.Value, r.Key.ToString()));
            ViewBag.CategoryId = _productsRepository.GetCategoriesDict().Select(r => new SelectListItem(r.Value, r.Key.ToString()));
            ViewBag.FuelId = _productsRepository.GetFuelsDict().Select(r => new SelectListItem(r.Value, r.Key.ToString()));
            return View("ProductForm", product);
        }
        public IActionResult Details(int id)
        {
            var item = _clientsRepository.GetClient(id);
            List<OrderItem> itemOrders = _ordersRepository.GetOrderDetails(item.OrderId);
            var categories = _productsRepository.GetCategoriesDict();
            Tuple<Client, List<OrderItem>,Dictionary<int,string>> info = new(item, itemOrders,categories);
            return View(info);
        }
        public IActionResult ProductsList()
        {
            ViewBag.BrandId = _productsRepository.GetBrandsDict();
            ViewBag.CategoryId = _productsRepository.GetCategoriesDict();
            ViewBag.FielId = _productsRepository.GetFuelsDict();
            //Tuple<IEnumerable<Product>, Dictionary<int, string>, Dictionary<int, string>, Dictionary<int, string>> info = new(_productsRepository.GetProducts(), _productsRepository.GetBrandsDict(), _productsRepository.GetCategoriesDict(),_productsRepository.GetFuelsDict());
            var info = _productsRepository.GetProducts();
            return View(info);
        }
        public RedirectToActionResult DeleteReview(int id)
        {
            _reviewsRepository.Delete(id);
            return RedirectToAction("ReviewsList");
        }
        public IActionResult ReviewsList()
        {
           
            var info = _reviewsRepository.GetReviews();
            return View(info);
        }
        [HttpPost]
        public IActionResult Save(Client client)
        {
            Client oldOrder = _clientsRepository.GetClient(client.Id);

            oldOrder.Name = client.Name;
            oldOrder.SurName = client.SurName;
            oldOrder.PhoneNumner = client.PhoneNumner;
            oldOrder.Adress = client.Adress;
            oldOrder.Email = client.Email;
            _ordersRepository.Save();
            return View("Main", _ordersRepository.GetOrders());
        }


    }
}
