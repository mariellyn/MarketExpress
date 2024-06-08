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

        public LoginController(IUserRepository userRepository, ISection section)
        {
            _userRepository = userRepository;
            _section = section;
        }

        public IActionResult Index()
        {
            if (_section.SearchUserSection() != null) return RedirectToAction("Index", "Home");
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
    }
}
