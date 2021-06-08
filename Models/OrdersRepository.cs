using SparePartsShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
   
    public class OrdersRepository:IAllOrders
    {
        private  AppDBContext _context;
        private  ShopCartRepository _shopCart;

        public OrdersRepository(AppDBContext content, ShopCartRepository shopCart)
        {
            _context = content;
            _shopCart = shopCart;
        }
      
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();

            var items = _shopCart.GetShopCartItems();

            foreach (var el in items)
            {
                var orderDetails = new OrderDetails
                {
                    ProductId = el.Product.Id,
                    OrderId = order.Id,
                    Price = (uint)el.Product.Cost
                    
                };
                _shopCart.DeleteItem(el.Id);
                _context.SaveChanges();
                _context.OrdersDetails.Add(orderDetails);
            }
            _context.SaveChanges();
        }
    }
}
