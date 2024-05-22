using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MarketExpress.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository) 
        { 
            _clientRepository = clientRepository;
        
        }
        public IActionResult Index()
        {
           List<ClientModel> client = _clientRepository.SearchAll();


            return View(client);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
           ClientModel client = _clientRepository.ListId(id);
            return View(client);
        }

        public IActionResult DeleteConfirmation(int id)
        {

            ClientModel client = _clientRepository.ListId(id);
            return View(client);
        }

        public IActionResult Delete(int id)

        {
            try

            {
                bool delete = _clientRepository.Delete(id);

                if (delete)
                {
                    TempData["MessageSucess"] = "Successfully delete customer.";

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
        public IActionResult Add(ClientModel client)
        {
           try

            {
                if (ModelState.IsValid)
                {
                    _clientRepository.Add(client);
                    TempData["MessageSucess"] = "Successfully registered customer.";
                    return RedirectToAction("Index");
                }
                return View(client);
            }

            catch (System.Exception error ) 
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }
           
        }

        [HttpPost]
        public IActionResult Edit(ClientModel client)
        {

            try

            {
                if (ModelState.IsValid)
                {
                    _clientRepository.Update(client);
                    TempData["MessageSucess"] = "Changed Successfully";
                    return RedirectToAction("Index");
                }

                return View("Edit", client);

            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
