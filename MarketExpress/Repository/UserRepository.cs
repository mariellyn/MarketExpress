﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;

namespace MarketExpress.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BancoContext _bancoContext;
        public UserRepository(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public UserModel SearchLogin(string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel ListIdUser(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Id == id);
        }
        public List<UserModel> UserAll()
        {
            return _bancoContext.Users.ToList();
        }
        public UserModel Add(UserModel Users)
        {
            Users.DateRegistration = DateTime.Now;
            Users.SetPasswordHash();
            _bancoContext.Users.Add(Users);
            _bancoContext.SaveChanges();
            return Users;
        }

        public UserModel Update(UserModel Users)
        {
            UserModel UsersDB = ListIdUser(Users.Id);

            if (UsersDB == null) throw new System.Exception("There was an error updating user");

            UsersDB.Name = Users.Name;
            UsersDB.Email = Users.Email;
            UsersDB.Login = Users.Login;
            UsersDB.Profile = Users.Profile;
            UsersDB.DateChanged = DateTime.Now;

            _bancoContext.Users.Update(UsersDB);
            _bancoContext.SaveChanges();
            return UsersDB;
        }

        public bool Delete(int id)
        {
            UserModel UsersDB = ListIdUser(id);

            if (UsersDB == null) throw new System.Exception("There was an error deleting user");

            _bancoContext.Users.Remove(UsersDB);
            _bancoContext.SaveChanges();

            return true;
        }


    }
}
