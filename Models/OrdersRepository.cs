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
        public void CreateOrder(Client client)
        {
            
             Order clientOrder = new Order();
            _context.Orders.Add(clientOrder);
            _context.SaveChanges();
            clientOrder = _context.Orders.OrderBy(x=>x.OrderTime).Last();
            
           

            var items = _shopCart.GetShopCartItems();
            
            foreach (var el in items)
            {
                // clientOrder.Products.Add(el);
                _shopCart.DeleteItem(el.Id);
                _context.OrderItems.Add(new OrderItem()
                {
                    OrderId = clientOrder.Id,
                    ProductId = el.ProductId,
                    ShopCartId = null
                });
                _context.SaveChanges();

            }
            // clientOrder.Client = client;
           // _context.Orders.Add(clientOrder);

            //_context.SaveChanges();
            // client.Order = clientOrder;
            client.OrderId = clientOrder.Id;
            _context.Clients.Add(client);
            _context.SaveChanges();
           
           
          
        }
        public Client GetClient(int id) =>
                    _context.Clients.FirstOrDefault(x => x.Id == id);

        public Order GetOrder(int id) =>
                    _context.Orders.FirstOrDefault(x => x.Id == id);

        public void DeleteOrder(int id)
        {
            var item = _context.Orders.FirstOrDefault(x => x.Id == id);
            _context.Orders.Remove(item);
            _context.Orders.Remove(_context.Orders.FirstOrDefault(x => x.Id == item.Id));
            _context.SaveChanges();
            var details = _context.OrderItems.Where(x => x.OrderId == item.Id);
            _context.OrderItems.RemoveRange(details);
            _context.SaveChanges();
        }
        public void DeleteDetails(int id)
        {
            var details = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            _context.OrderItems.Remove(details);
            _context.SaveChanges();
        }
        public List<OrderItem> GetOrderDetails(int orderId)
        {
            List<OrderItem> orderItems = _context.OrderItems.Where(x => x.OrderId == orderId).ToList();
            foreach (var el in orderItems)
            {
                int id = el.ProductId;
                el.Product = _context.Products.FirstOrDefault(x => x.Id == id);
            }
            return orderItems;
        }
        public List<Client> GetClients()
        {
            var items  = _context.Clients.ToList();
            return items;
        }
        public List<Order> GetOrders()
        {
            var items = _context.Orders.ToList();
            return items;
        }
        // public List<Order> GetOrders() => _context.Orders.ToList();
    }
}
