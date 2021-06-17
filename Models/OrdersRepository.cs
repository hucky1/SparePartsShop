using SparePartsShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class OrdersRepository
    {
        private AppDBContext _context;
        private  ShopCartRepository _shopCart;
        
        
        public OrdersRepository(AppDBContext context, ShopCartRepository shopCart)
        {
            _context = context; 
            _shopCart = shopCart;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        //public void CreateOrder(Order order)
        //{
        //    order.OrderTime = DateTime.Now;
        //    _context.Orders.Add(order);
        //    _context.SaveChanges();

        //    var items = _shopCart.GetShopCartItems();

        //    foreach (var el in items)
        //    {
        //        OrderDetails orderDetails = new OrderDetails
        //        {
        //            ProductId = el.Product.Id,
        //            OrderId = order.Id,
        //            Price = (uint)el.Product.Cost,
        //            Product = el.Product,
        //            Order = order
                    
                    
        //        };
        //        _context.SaveChanges();
        //        _shopCart.DeleteItem(el.Id);
        //        _context.SaveChanges();
        //        _context.OrdersDetails.Add(orderDetails);
        //    }
        //    _context.SaveChanges();
        //}
        //public Order GetOrder(int id)=>
        //            _context.Orders.FirstOrDefault(x => x.Id == id);
        
        //public void DeleteOrder(int id)
        //{
        //    var item = _context.Orders.FirstOrDefault(x => x.Id == id);
        //    _context.Orders.Remove(item);
        //    _context.SaveChanges();
        //    var details = _context.OrdersDetails.Where(x => x.OrderId == id);
        //    _context.OrdersDetails.RemoveRange(details);
        //    _context.SaveChanges();
        //}
        //public void DeleteDetails(int id)
        //{
        //    var details = _context.OrdersDetails.FirstOrDefault(x => x.Id == id);
        //    _context.OrdersDetails.Remove(details);
        //    _context.SaveChanges();
        //}
        //public List<OrderDetails> GetOrderDetails(int orderId)
        //{
        //    List<OrderDetails> orderItems = _context.OrdersDetails.Where(x => x.OrderId == orderId).ToList();
        //    foreach(var el in orderItems)
        //    {
        //        int id = el.ProductId;
        //        el.Product = _context.Products.FirstOrDefault(x => x.Id == id);
        //    }
        //    return orderItems;
        //}
        public List<Order> GetOrders()
        {
            var items  = _context.Orders.ToList();
            return items;
        }
       // public List<Order> GetOrders() => _context.Orders.ToList();
    }
}
