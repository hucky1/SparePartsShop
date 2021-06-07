using Microsoft.AspNetCore.Mvc;
using SparePartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Controllers
{
    public class OrderController : Controller
    {
        private  IAllOrders _orderRepository;
        private  ShopCartRepository _shopCart;

        public OrderController(IAllOrders orderRepository, ShopCartRepository shopCart)
        {
            _orderRepository = orderRepository;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Order order)
        {
          
            
           
            
            if (_shopCart.GetShopCartItems().Count == 0)
            {
                ModelState.AddModelError("", "Вы не выбрали товары для покупки.");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан.";
            return View();
        }
    }
}
