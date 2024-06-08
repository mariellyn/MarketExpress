﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;


namespace MarketExpress.Repository
{
    public interface IUserRepository
    {
        List<UserModel> UserAll();
        UserModel ListIdUser(int id);
        
        UserModel Add(UserModel user);

        UserModel Update(UserModel user);

        bool Delete(int id);
    }
}
