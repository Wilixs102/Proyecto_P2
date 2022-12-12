using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_P1.Data;
using Proyecto_P1.Models;
using Proyecto_P1.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_P1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Proyecto_P1Context _context;

        public HomeController(ILogger<HomeController> logger, Proyecto_P1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult IniciarSesion(string email, string contrasenia)
        {
            Usuario? u = _context.Usuario.FirstOrDefault(u => u.Correo == email);
            if(u is null)
            {
                return RedirectToAction("Inicio");
            }

            if(u.Contraseña != contrasenia)
            {
                return RedirectToAction("Inicio");
            }

            return RedirectToAction("Index");
        }


    }
}