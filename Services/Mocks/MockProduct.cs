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
        private static IProductsCategory _productsCategory { get; set; }
        private static IBrand _brand { get; set; }
        public MockProduct(IProductsCategory productsCategory, IBrand brand)
        {
            _productsCategory = productsCategory;
            _brand = brand;
        }

      
        


        public List<Product> GetAll {
            get
            {
                return new List<Product>
                {
                    new Product{Cost = 18, CarBody = "Джип (5-дверный)", EngineCapacity = "3 л", FuelType = "Дизель",
                        Model = "X5 E53 2000-2007",ProductionYear = "2009", Img = "",
                        Brand =  _brand.GetAllBrands
                        .Where (x=> x.Id ==1)
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.Id==1)
                        .FirstOrDefault()
                    },
                     new Product{Cost = 13, CarBody = "Джип (5-дверный)", EngineCapacity = "5 л", FuelType = "Бензин",
                        Model = "ML W164 2005-2011",ProductionYear = "2005",Img = "",
                        Brand =  _brand.GetAllBrands
                         .Where (x=> x.Id ==2)
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.Id==1)
                        .FirstOrDefault()
                    },
                      new Product{Cost = 25, CarBody = "Купе", EngineCapacity = "2 л", FuelType = "Бензин",
                        Model = "TT 2006-2010",ProductionYear = "2007",Img = "",
                        Brand =  _brand.GetAllBrands
                         .Where (x=> x.Id ==3)
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.Id==1)
                        .FirstOrDefault()
                    },
                       new Product{Cost = 13, CarBody = "Хэтчбэк 5 дв.", EngineCapacity = "1.5 л", FuelType = "Дизель",
                        Model = "SuperB 2008-2015",ProductionYear = "2012",Img = "",
                        Brand =  _brand.GetAllBrands
                         .Where (x=> x.Id ==4)
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                        .Where(x=> x.Id==1)
                        .FirstOrDefault()
                    },
                        new Product{Cost = 25, CarBody = "Джип (5-дверный)", EngineCapacity = "3.7 л", FuelType = "	Бензин",
                        Model = "H3",ProductionYear = "2008", Img = "",
                        Brand =  _brand.GetAllBrands
                         .Where (x=> x.Id ==5)
                        .FirstOrDefault(),
                        Category = _productsCategory.GetAllCategories
                       .Where(x=> x.Id==1)
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
