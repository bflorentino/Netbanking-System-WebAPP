﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Estas en el modulo de administradores";
            return View();
        }
    }
}
