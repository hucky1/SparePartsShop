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
        
        public void Delete(int id)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(x=>x.Id==id));
            _context.SaveChanges();
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
        public Dictionary<int, string> GetFuelsDict()
        {
            Dictionary<int, string> fuels = new Dictionary<int, string>();
            _context.Fuels.ToList().ForEach(x => fuels.Add(x.Id, x.Name));
            return fuels;
        }
        public Product GetProduct(Product product)
        {
            Product prod = _context.Products.SingleOrDefault(g => g.Id == product.Id);
            return prod;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
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
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            var items = _context.Products.Where(x => x.Category.Id == categoryId).ToList();
            return items;
        }
        public IEnumerable<Product> GetByBrand(int brandId)
        {
            var items = _context.Products.Where(x => x.Brand.Id == brandId).ToList();
            return items;
        }

    }
}
