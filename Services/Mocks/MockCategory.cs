﻿using SparePartsShop.Models;
using SparePartsShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> GetAllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Амортизатор капота", Description="Амортизатор капота или, как его часто называют, газовый упор — устройство для безопасного открытия/закрытия капота и его удерживания в открытом состоянии."
                    },
                    new Category{CategoryName="Бак топливный", Description="Тоопливный бак — ёмкость для хранения запаса жидкого топлива непосредственно на борту транспортного средства или технического устройства, получающего энергию от жидкотопливного двигателя внутреннего сгорания."
                    },
                    new Category{CategoryName="Бампер", Description="Бампер — энергопоглощающее устройство автомобиля в виде бруса, расположенного спереди и сзади."
                    },
                    new Category{CategoryName="Глушитель", Description="Глушитель — устройство для снижения шума от выходящих в атмосферу газов или воздуха из различных устройств."
                    },
                    new Category{CategoryName="Магнитола", Description="Магнитола — часть акустической системы машины. Обычно магнитола расположена в приборной панели и нужна, чтобы проигрывать песни, фильмы и клипы. Некоторые модели могут показывать маршрут и услуги на карте, транслировать телевидение, подключаться к телефону через USB-кабель, Bluetooth или разъём AUX."
                    }
                };
            }
        }
    }
}