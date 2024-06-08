using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarketExpress.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)

        {
            _userRepository = userRepository;

        }
        public IActionResult Index()
        {
            List<UserModel> user = _userRepository.UserAll();


            return View(user);
        }


        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {

            UserModel user = _userRepository.ListIdUser(id);
            return View(user);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            UserModel user = _userRepository.ListIdUser(id);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            try

            {
                bool delete = _userRepository.Delete(id);

                if (delete)
                {
                    TempData["MessageSucess"] = "Successfully delete .";

                }

                else
                {

                    TempData["MessageError"] = "Oops, please try again.";
                }

                return RedirectToAction("Index");
            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, please try again.  Error Detail : {error.Message} ";
                return RedirectToAction("Index");
            }

        }




        [HttpPost]
        public IActionResult Add(UserModel user)
        {
            try

            {
                if (ModelState.IsValid)
                {
                    _userRepository.Add(user);
                    TempData["MessageSucess"] = "Successfully registered user.";
                    return RedirectToAction("Index");
                }
                return View(user);
            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered user, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(UserPasswordModel userPasswordModel)
        {

            try

            {
                UserModel user = null;
                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {

                        Id = userPasswordModel.Id,
                        Name = userPasswordModel.Name,
                        Login = userPasswordModel.Login,
                        Email = userPasswordModel.Email,
                        Profile = userPasswordModel.Profile


                    };

                    user = _userRepository.Update(user);
                    TempData["MessageSucess"] = "Changed Successfully";
                    return RedirectToAction("Index");
                }

                return View("Edit", user);

            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered user, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
