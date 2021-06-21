using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SparePartsShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class ShopCartRepository
    {
        private AppDBContext _context;
        public ShopCartRepository(AppDBContext context)
        {
            _context = context;
        }
        public string ShopCartId { get; set; }

        public static ShopCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCartId = session.GetString("CatrId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCartRepository(context) { ShopCartId = shopCartId }; 
             
        }
        public void AddToCart(Product product)
        {
            _context.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                ProductId = product.Id
            });
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var item = _context.ShopCartItems.FirstOrDefault(x => x.Id == id);
            _context.ShopCartItems.Remove(item);
            _context.SaveChanges();
        }
        public decimal ComputeTotalValue() =>
            GetShopCartItems().Sum(e => e.Product.Cost);
 
        public List<ShopCartItem> GetShopCartItems()
        {
            return _context.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s=> s.Product).ToList();
        }
    }
}
