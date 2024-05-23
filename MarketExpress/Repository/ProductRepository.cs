using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;


namespace MarketExpress.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly BancoContext _bancoContext;
        public ProductRepository(BancoContext bancoContext)
        {

            _bancoContext = bancoContext;
        }
        public ProductModel ListIdProduct(int id)
        {
            return _bancoContext.Product.FirstOrDefault(x => x.Id == id);
        }

        public List<ProductModel> ProductAll()
        {
            return _bancoContext.Product.ToList();
        }

        public ProductModel Add(ProductModel product)
        {
            _bancoContext.Product.Add(product);
            _bancoContext.SaveChanges();

            return product;
        }

        public ProductModel Update(ProductModel product)
        {
            ProductModel productDB = ListIdProduct(product.Id);

            if (productDB == null) throw new System.Exception("There was an error updating product");

            productDB.Description = product.Description;
            productDB.Price = product.Price;
            productDB.QuantityStock = product.QuantityStock;
            productDB.Weigth = product.Weigth;
            productDB.Category = product.Category;

            _bancoContext.Product.Update(productDB);
            _bancoContext.SaveChanges();

            return productDB;
        }

        public bool Delete(int id)
        {
            ProductModel productDB = ListIdProduct(id);

            if (productDB == null) throw new System.Exception("There was an error deleting sales");

            _bancoContext.Product.Remove(productDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
