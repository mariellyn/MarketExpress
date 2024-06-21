using MarketExpress.Helper;
using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MarketExpress.Controllers
{
    public class ChangePasswordController : Controller

    {

        private readonly IUserRepository _userRepository;
        private readonly ISection _section;

        public ChangePasswordController(IUserRepository userRepository,
                                        ISection section)
        {
            _userRepository = userRepository;
            _section = section;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel changePasswordModel)
        {
            try
            {
                UserModel userModel = _section.SearchUserSection();
                changePasswordModel.Id = userModel.Id;

                if (ModelState.IsValid)
                {

                    _userRepository.ChangePassword(changePasswordModel);
                    TempData["MessageSuccess"] = "Password changed successfully.";
                    return RedirectToAction("Index");
                }

                TempData["MessageError"] = "There were validation errors. Please correct them and try again.";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MessageError"] = $"Ops,We can't change the password, try again. Error: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
