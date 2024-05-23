using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;

namespace MarketExpress.Repository
{
    public interface ICategoryRepository
    {
        CategoryModel ListIdCategory(int id);
        List<CategoryModel> CategoriesAll();
        CategoryModel Add(CategoryModel category);

        CategoryModel Update(CategoryModel category);   

        bool Delete(int id);    
    }
}
