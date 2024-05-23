using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;

namespace MarketExpress.Repository
{
    public interface IProductRepository
    {
        ProductModel ListIdProduct(int id);
        List<ProductModel> ProductAll();
        ProductModel Add(ProductModel product);

        ProductModel Update(ProductModel product);

        bool Delete(int id);
    }
}
