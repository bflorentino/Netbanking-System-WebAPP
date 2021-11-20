﻿using Microsoft.AspNetCore.Mvc;
using Bussiness.Model.BindingModel;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AdminClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateClient(ClientCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Bussiness.BussinesLogic.AdmClientes.CreateCliente(model) ;
                return RedirectToAction("ViewClientes");
            }
            return View(model);
        }

        public IActionResult EditCliente()
        {
            return View();
        }

        public IActionResult ViewClientes()
        {
            var clientes =  Bussiness.BussinesLogic.AdmClientes.GetClientes();
    
            return  View(clientes);
        }
    }
}