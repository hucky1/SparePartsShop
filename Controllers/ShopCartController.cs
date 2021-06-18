using Microsoft.AspNetCore.Mvc;
using SparePartsShop.Models;
using SparePartsShop.Services.Data;
using SparePartsShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Controllers
{
    public class ShopCartController : Controller
    {
        private ProductsRepository _productsRepository;
        private ShopCartRepository _shopCart;

        public ShopCartController(ProductsRepository productsRepository, ShopCartRepository shopCart)
        {
            _productsRepository = productsRepository;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var Items = _shopCart.GetShopCartItems();
            var shopCartVM = new ShopCartViewModel
            {
                _shopCart = this._shopCart
            };
            return View(shopCartVM);
        }
        public RedirectToActionResult Delete(int id)
        {
            _shopCart.DeleteItem(id);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _productsRepository.GetProducts().FirstOrDefault(x => x.Id == id);
            if (item is not null)
                _shopCart.AddToCart(item);
            return RedirectToAction("Index");
        }

    }
}
