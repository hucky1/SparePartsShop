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

        public  void Initial()
        {
                if (_context.Brands.Any() || _context.Categories.Any() || _context.Products.Any())
                    return;

                _context.Brands.AddRange(_brand);
                _context.Categories.AddRange(_productsCategory);
                _context.Products.AddRange(_products);

                _context.SaveChanges();
        }
        private static readonly List<Brand> _brand = new()
        {
            new Brand { Name = "BMW", Description = "Немецкий производитель автомобилей, мотоциклов, двигателей, а также велосипедов"/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="BMW").ToList()*/ },
            new Brand { Name = "Mercedes", Description = "Торговая марка и одноимённая компания — производитель легковых автомобилей премиального класса, грузовых автомобилей, автобусов и других транспортных средств, входящая в состав немецкого концерна «Daimler AG». Является одним из самых узнаваемых автомобильных брендов во всём мире[5]. Штаб-квартира Mercedes-Benz находится в Штутгарте, Баден-Вюртемберг, Германия. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Mercedes").ToList()*/},
            new Brand { Name = "Audi", Description = "Немецкая автомобилестроительная компания в составе концерна Volkswagen Group, специализирующаяся на выпуске автомобилей под маркой Audi. Штаб-квартира расположена в городе Ингольштадт (Германия). Девиз — Vorsprung durch Technik (с нем. — «Прогресс через технологии»). Объём производства в 2016 году составил около 1 903 259 автомобилей. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Audi").ToList()*/},
            new Brand { Name = "Skoda", Description = "Крупнейший производитель автомобилей в Чешской Республике, со штаб-квартирой, расположенной в городе Млада-Болеслав. Фактически является продолжателем компании Laurin & Klement, зарождённой в 1895 году, и ставшей в 1925-м частью промышленного конгломерата «Akciová společnost, dříve Škodovy závody» (сейчас — Škoda Holding). После приватизации, произошедшей в 1991 году, Škoda Auto была поэтапно поглощена немецким концерном Volkswagen Group, является на сегодня крупнейшим чешским экспортёром и одним из крупнейших чешских работодателей. Автомобили Škoda продаются более чем в 100 странах и по итогам 2018 года общий объём продаж в мире превысил 1,25 млн единиц. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Skoda").ToList()*/},
            new Brand { Name = "Hummer", Description = "Ребрендинговое название для гражданского автомобиля, созданного на базе военного автомобиля HMMWV. Из-за активной рекламы марки и редкости машины в России, «Хаммером» иногда неточно называют военный HMMWV. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Hummer").ToList()*/}
        };
        private static readonly List<Category> _productsCategory = new List<Category>()
        {
            new Category{CategoryName="Амортизатор капота", Description="Амортизатор капота или, как его часто называют, газовый упор — устройство для безопасного открытия/закрытия капота и его удерживания в открытом состоянии." /*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Амортизатор капота").ToList()*/
                    },
                    new Category{CategoryName="Бак топливный", Description="Топливный бак — ёмкость для хранения запаса жидкого топлива непосредственно на борту транспортного средства или технического устройства, получающего энергию от жидкотопливного двигателя внутреннего сгорания."/*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Бак топливный").ToList()*/
                    },
                    new Category{CategoryName="Бампер", Description="Бампер — энергопоглощающее устройство автомобиля в виде бруса, расположенного спереди и сзади.",/*Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Бампер").ToList()*/
                    },
                    new Category{CategoryName="Глушитель", Description="Глушитель — устройство для снижения шума от выходящих в атмосферу газов или воздуха из различных устройств."/*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Глушитель").ToList()*/
                    },
                    new Category{CategoryName="Магнитола", Description="Магнитола — часть акустической системы машины. Обычно магнитола расположена в приборной панели и нужна, чтобы проигрывать песни, фильмы и клипы. Некоторые модели могут показывать маршрут и услуги на карте, транслировать телевидение, подключаться к телефону через USB-кабель, Bluetooth или разъём AUX."/*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Магнитола").ToList()*/
                    }
        };
        private static readonly List<Product> _products = new()
        {
            new Product
            {
                Cost = 18,
                CarBody = "Джип (5-дверный)",
                EngineCapacity = "3 л",
                FuelType = "Дизель",
                Model = "X5 E53 2000-2007",
                ProductionYear = "2009",
                Img = "",
                Brand = _brand
                        .Where(x => x.Name == "BMW")
                        .FirstOrDefault(),
                Category = _productsCategory
                        .Where(x => x.CategoryName == "Амортизатор капота")
                        .FirstOrDefault()
            },
            new Product
            {
                Cost = 13,
                CarBody = "Джип (5-дверный)",
                EngineCapacity = "5 л",
                FuelType = "Бензин",
                Model = "ML W164 2005-2011",
                ProductionYear = "2005",
                Img = "",
                Brand = _brand
                         .Where(x => x.Name == "Mercedes")
                        .FirstOrDefault(),
                Category = _productsCategory
                        .Where(x => x.CategoryName == "Амортизатор капота")
                        .FirstOrDefault()
            },
            new Product
            {
                Cost = 25,
                CarBody = "Купе",
                EngineCapacity = "2 л",
                FuelType = "Бензин",
                Model = "TT 2006-2010",
                ProductionYear = "2007",
                Img = "",
                Brand = _brand
                         .Where(x => x.Name == "Audi")
                        .FirstOrDefault(),
                Category = _productsCategory
                        .Where(x => x.CategoryName == "Амортизатор капота")
                        .FirstOrDefault()
            },
            new Product
            {
                Cost = 13,
                CarBody = "Хэтчбэк 5 дв.",
                EngineCapacity = "1.5 л",
                FuelType = "Дизель",
                Model = "SuperB 2008-2015",
                ProductionYear = "2012",
                Img = "",
                Brand = _brand
                         .Where(x => x.Name == "Skoda")
                        .FirstOrDefault(),
                Category = _productsCategory
                       .Where(x => x.CategoryName == "Амортизатор капота")
                        .FirstOrDefault()
            },
            new Product
            {
                Cost = 25,
                CarBody = "Джип (5-дверный)",
                EngineCapacity = "3.7 л",
                FuelType = "	Бензин",
                Model = "H3",
                ProductionYear = "2008",
                Img = "",
                Brand = _brand
                         .Where(x => x.Name == "Hummer")
                        .FirstOrDefault(),
                Category = _productsCategory
                       .Where(x => x.CategoryName == "Амортизатор капота")
                        .FirstOrDefault()
            },
        };
    }
}
