using SparePartsShop.Models;
using SparePartsShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Mocks
{
    public class MockBrand : IBrand
    {
        public List<Brand> GetAllBrands
        {
            get
            {
                return new List<Brand>
                {
                    new Brand{Id =1 , Name = "BMW", Description = "Немецкий производитель автомобилей, мотоциклов, двигателей, а также велосипедов"/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="BMW").ToList()*/ },
                    new Brand{Id =2 , Name = "Mercedes", Description = "Торговая марка и одноимённая компания — производитель легковых автомобилей премиального класса, грузовых автомобилей, автобусов и других транспортных средств, входящая в состав немецкого концерна «Daimler AG». Является одним из самых узнаваемых автомобильных брендов во всём мире[5]. Штаб-квартира Mercedes-Benz находится в Штутгарте, Баден-Вюртемберг, Германия. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Mercedes").ToList()*/},
                    new Brand{Id =3 , Name = "Audi", Description = "Немецкая автомобилестроительная компания в составе концерна Volkswagen Group, специализирующаяся на выпуске автомобилей под маркой Audi. Штаб-квартира расположена в городе Ингольштадт (Германия). Девиз — Vorsprung durch Technik (с нем. — «Прогресс через технологии»). Объём производства в 2016 году составил около 1 903 259 автомобилей. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Audi").ToList()*/},
                    new Brand{Id =4 , Name = "Skoda", Description = "Крупнейший производитель автомобилей в Чешской Республике, со штаб-квартирой, расположенной в городе Млада-Болеслав. Фактически является продолжателем компании Laurin & Klement, зарождённой в 1895 году, и ставшей в 1925-м частью промышленного конгломерата «Akciová společnost, dříve Škodovy závody» (сейчас — Škoda Holding). После приватизации, произошедшей в 1991 году, Škoda Auto была поэтапно поглощена немецким концерном Volkswagen Group, является на сегодня крупнейшим чешским экспортёром и одним из крупнейших чешских работодателей. Автомобили Škoda продаются более чем в 100 странах и по итогам 2018 года общий объём продаж в мире превысил 1,25 млн единиц. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Skoda").ToList()*/},
                    new Brand{Id =5 , Name = "Hummer", Description = "Ребрендинговое название для гражданского автомобиля, созданного на базе военного автомобиля HMMWV. Из-за активной рекламы марки и редкости машины в России, «Хаммером» иногда неточно называют военный HMMWV. "/*,Products = new MockProduct().GetAll.Where(x=> x.Brand.Name=="Hummer").ToList()*/}
                };
            }
        }
    }
}
