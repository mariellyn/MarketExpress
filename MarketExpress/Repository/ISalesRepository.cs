using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;


namespace MarketExpress.Repository
{
    public interface ISalesRepository
    {
        SalesModel ListIdSales(int id);
        List<SalesModel> SaleAll();
        SalesModel Add(SalesModel sales);

        SalesModel Update(SalesModel sales);

        bool Delete(int id);
    }
}
