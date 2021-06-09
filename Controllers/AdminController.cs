using Microsoft.AspNetCore.Mvc;
using SparePartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Controllers
{
    public class AdminController : Controller
    {

        private OrdersRepository _ordersRepository;

        public AdminController(OrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IActionResult Index()=>
            View(_ordersRepository.GetOrders());
        
        public RedirectToActionResult Delete(int id)
        {
            _ordersRepository.DeleteOrder(id);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult DeleteDetails(int id)
        {
            _ordersRepository.GetOrderDetails(id);
            return RedirectToAction("Details");
        }
        public IActionResult Details(int id)
        {
            var item = _ordersRepository.GetOrder(id);
            List<OrderDetails> itemOrders = _ordersRepository.GetOrderDetails(id);
            Tuple<Order, List<OrderDetails>> info = new(item, itemOrders);
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
