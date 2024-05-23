using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;

namespace MarketExpress.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BancoContext _bancoContext;
        public CategoryRepository(BancoContext bancoContext) 
        { 
           this._bancoContext = bancoContext;
        }


        public CategoryModel ListIdCategory(int id)
        {
            return _bancoContext.Category.FirstOrDefault(x => x.Id == id);
        }

        public List<CategoryModel> CategoriesAll()
        {
            return _bancoContext.Category.ToList();
        }


        public CategoryModel Add(CategoryModel category)
        {
            _bancoContext.Category.Add(category);
            _bancoContext.SaveChanges();

            return category;
        }

        public CategoryModel Update(CategoryModel category)
        {
            CategoryModel categoryDB = ListIdCategory(category.Id);

            if (categoryDB == null) throw new System.Exception("There was an error updating category");

            categoryDB.Name = category.Name;
            categoryDB.Description = category.Description;  

            _bancoContext.Category.Update(categoryDB);
            _bancoContext.SaveChanges();

            return categoryDB;

        }

        public bool Delete(int id)
        {
            CategoryModel categoryDB = ListIdCategory(id);

            if (categoryDB == null) throw new System.Exception("There was an error delete category");

            _bancoContext.Category.Remove(categoryDB);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
