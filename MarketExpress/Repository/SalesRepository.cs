using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;


namespace MarketExpress.Repository
{
    public class SalesRepository : ISalesRepository
    {

        private readonly BancoContext _bancoContext;
        public SalesRepository(BancoContext bancoContext)
        {

            _bancoContext = bancoContext;
        }
        public SalesModel ListIdSales(int id)
        {
            return _bancoContext.Sales.FirstOrDefault(x => x.Id == id);
        }

           public List<SalesModel> SaleAll()
        {
            return _bancoContext.Sales.ToList();
        }     
        
        public SalesModel Add(SalesModel sales)
        {
            _bancoContext.Sales.Add(sales);
            _bancoContext.SaveChanges();

            return sales;
        }

        public SalesModel Update(SalesModel sales)
        {
            SalesModel salesDB = ListIdSales(sales.Id);

            if (salesDB == null) throw new System.Exception("There was an error updating sales");

            salesDB.SaleIdentifier = sales.SaleIdentifier;
            salesDB.Date = sales.Date;
            salesDB.Hour = sales.Hour;
            salesDB.Client = sales.Client;
            salesDB.ProductsSold = sales.ProductsSold;
            salesDB.Observations = sales.Observations;
            salesDB.FinalPrice = sales.FinalPrice;
            salesDB.OrderStatus = sales.OrderStatus;
            salesDB.Payment = sales.Payment;


            _bancoContext.Sales.Update(salesDB);
            _bancoContext.SaveChanges();

            return salesDB;
        }

        public bool Delete(int id)
        {
            SalesModel salesDB = ListIdSales(id);

            if (salesDB == null) throw new System.Exception("There was an error deleting sales");

            _bancoContext.Sales.Remove(salesDB);
            _bancoContext.SaveChanges(); 
            return true;
        }
    }
}
