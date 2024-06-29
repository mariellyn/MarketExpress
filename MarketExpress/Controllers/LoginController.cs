using MarketExpress.Helper;
using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MarketExpress.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISection _section;
        private readonly IEmail _email;

        public LoginController(IUserRepository userRepository,
                               ISection section,
                               IEmail email)
        {
            _userRepository = userRepository;
            _section = section;
            _email = email;
        }

        public IActionResult Index()
        {
            if (_section.SearchUserSection() != null) return RedirectToAction("Index", "Home");
            return View();
        }


        public IActionResult ResetPassword() 
        {
            return View();
        }



        public IActionResult End()
        {
            _section.RemoveUserSection();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchLogin(loginModel.Login);
                    if (user != null && user.PasswordValid(loginModel.Password))
                    {
                        _section.CreateUserSection(user);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MessageError"] = "Login or password is incorrect.";
                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MessageError"] = $"An error occurred: {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost] 
        public IActionResult SendSendLinkResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchEmailLogin(resetPasswordModel.Email , resetPasswordModel.Login);

                    if (user != null)
                    {

                        string newPassword = user.GenerateNewPassword();
                        
                        string message = $" Your new password : {newPassword}";

                        bool emailSend = _email.Send(user.Email, "Contacts System - New Password", message);

                        if (emailSend)
                        {

                            _userRepository.Update(user);
                            TempData["MessageSucess"] = $" We've sent you a new password. ";
                        }
                        else
                        {
                            TempData["MessageError"] = $" We can't send your password.Please try again. ";
                        }

                        
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MessageError"] = $" We can't reset your password.Please check the information provided and try again. ";
                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MessageError"] = $"An error occurred: {error.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
