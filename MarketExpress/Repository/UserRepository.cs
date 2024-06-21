using System;
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

        public UserModel SearchEmailLogin(string email, string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
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

        public UserModel ChangePassword(ChangePasswordModel changePasswordModel)
        {
            UserModel userDB = ListIdUser(changePasswordModel.Id);

            if (userDB == null) throw new Exception("An error occurred while updating the password, User Not Found");

            if (!userDB.PasswordValid(changePasswordModel.CurrentPassword)) throw new Exception("Current password does not match");

            if (userDB.PasswordValid(changePasswordModel.NewPassword)) throw new Exception("New password must be different from the current password.");

            userDB.SetNewPassword(changePasswordModel.NewPassword); 
            userDB.DateChanged = DateTime.Now; 

            _bancoContext.Users.Update(userDB);
            _bancoContext.SaveChanges();

            return userDB;
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
