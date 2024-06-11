using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;


namespace MarketExpress.Repository
{
    public interface IUserRepository
    {

        UserModel SearchLogin(string login);
        UserModel SearchEmailLogin(string email , string login);
        List<UserModel> UserAll();
        UserModel ListIdUser(int id);
        
        UserModel Add(UserModel user);

        UserModel Update(UserModel user);

        bool Delete(int id);
    }
}
