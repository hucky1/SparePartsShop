using SparePartsShop.Models;
using SparePartsShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Mocks
{
    public class MockCategory : IProductsCategory
    {
        public List<Category> GetAllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{Id =1 ,CategoryName="Амортизатор капота", Description="Амортизатор капота или, как его часто называют, газовый упор — устройство для безопасного открытия/закрытия капота и его удерживания в открытом состоянии." /*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Амортизатор капота").ToList()*/
                    },
                    new Category{Id =2 ,CategoryName="Бак топливный", Description="Топливный бак — ёмкость для хранения запаса жидкого топлива непосредственно на борту транспортного средства или технического устройства, получающего энергию от жидкотопливного двигателя внутреннего сгорания."/*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Бак топливный").ToList()*/
                    },
                    new Category{Id =3 ,CategoryName="Бампер", Description="Бампер — энергопоглощающее устройство автомобиля в виде бруса, расположенного спереди и сзади.",/*Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Бампер").ToList()*/
                    },
                    new Category{Id =4 ,CategoryName="Глушитель", Description="Глушитель — устройство для снижения шума от выходящих в атмосферу газов или воздуха из различных устройств."/*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Глушитель").ToList()*/
                    },
                    new Category{Id =5 ,CategoryName="Магнитола", Description="Магнитола — часть акустической системы машины. Обычно магнитола расположена в приборной панели и нужна, чтобы проигрывать песни, фильмы и клипы. Некоторые модели могут показывать маршрут и услуги на карте, транслировать телевидение, подключаться к телефону через USB-кабель, Bluetooth или разъём AUX."/*,Products = new MockProduct().GetAll.Where(x=> x.Category.CategoryName =="Магнитола").ToList()*/
                    }
                };
            }
        }
    }
}
