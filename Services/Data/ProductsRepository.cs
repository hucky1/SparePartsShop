using SparePartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Data
{
    public class ProductsRepository
    {
        //класс-репозиторий напрямую обращается к контексту базы данных
        private AppDBContext _context;
        public ProductsRepository(AppDBContext context)
        {
            _context = context;
        }

        public Dictionary<int,string> GetBrandsDict()
        {
            Dictionary<int, string> brands = new Dictionary<int, string>();
            _context.Brands.ToList().ForEach(x => brands.Add(x.Id, x.Name));
            return brands;
        }
        public Dictionary<int, string> GetCategoriesDict()
        {
            Dictionary<int, string> categories = new Dictionary<int, string>();
            _context.Categories.ToList().ForEach(x => categories.Add(x.Id, x.CategoryName));
            return categories;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

    }
}
