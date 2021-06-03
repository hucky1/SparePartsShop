using SparePartsShop.Models;
using SparePartsShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Mocks
{
    public class MockProduct : IAllProducts
    {
        private readonly IProductsCategory _productsCategory = new MockCategory();
        private readonly IBrand _brand = new MockBrand();
        public IEnumerable<Product> GetAll {
            get
            {
                return new List<Product>
                {
                    new Product{Cost = 18, CarBody = "Джип (5-дверный)", EngineCapacity = "3 л", FuelType = "Дизель",
                        Model = "X5 E53 2000-2007",ProductionYear = "2009", Img = "",
                        Brand =  _brand.GetAllBrands
                        .Where (x=> x.Name == "BMW")
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.CategoryName=="Амортизатор капота")
                        .FirstOrDefault()
                    },
                     new Product{Cost = 13, CarBody = "Джип (5-дверный)", EngineCapacity = "5 л", FuelType = "Бензин",
                        Model = "ML W164 2005-2011 ",ProductionYear = "2005",Img = "",
                        Brand =  _brand.GetAllBrands
                        .Where (x=> x.Name == "Mercedes")
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.CategoryName=="Амортизатор капота")
                        .FirstOrDefault()
                    },
                      new Product{Cost = 25, CarBody = "Купе", EngineCapacity = "2 л", FuelType = "Бензин",
                        Model = "TT 2006-2010",ProductionYear = "2007",Img = "",
                        Brand =  _brand.GetAllBrands
                        .Where (x=> x.Name == "Audi")
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.CategoryName=="Амортизатор капота")
                        .FirstOrDefault()
                    },
                       new Product{Cost = 13, CarBody = "Хэтчбэк 5 дв.", EngineCapacity = "1.5 л", FuelType = "Дизель",
                        Model = "SuperB 2008-2015",ProductionYear = "2012",Img = "",
                        Brand =  _brand.GetAllBrands
                        .Where (x=> x.Name == "Skoda")
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.CategoryName=="Амортизатор капота")
                        .FirstOrDefault()
                    },
                        new Product{Cost = 25, CarBody = "Джип (5-дверный)", EngineCapacity = "3.7 л", FuelType = "	Бензин",
                        Model = "H3",ProductionYear = "2008", Img = "",
                        Brand =  _brand.GetAllBrands
                        .Where (x=> x.Name == "Hummer")
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.CategoryName=="Амортизатор капота")
                        .FirstOrDefault()
                    },
                };
                
            }
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
