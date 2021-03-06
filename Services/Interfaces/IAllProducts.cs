using SparePartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Interfaces
{
    public interface IAllProducts
    {
        List<Product> GetAll { get;}

        Product GetProduct(int productId);    
    }
}
