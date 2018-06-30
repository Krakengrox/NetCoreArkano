using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcArkano.Models;
using System.Net.Http;
using ApiRest.Modelos;
using Newtonsoft.Json;
using System.Text;

namespace McvArkano.Controllers
{
    /// <summary>
    /// Controlador principal
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Controlador get para la vista computers, manejo de lógica de negocios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Computers()
        {
            ConnectionManager.GetComputers();
            List<Computer> computers = ConnectionManager.GetComputers();
            computers.RemoveAll(x => x.memory < 8);
            return View(computers);
        }

        public ActionResult CreateComputer()
        {
            return View();
        }


        /// <summary>
        /// Controlador post para el servidor, manejo de lógica de negocios
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult CreateComputer(Computer cp, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;
                ConnectionManager.PostComputers(cp);
                return RedirectToAction(nameof(Computers));
            }
            else
            {
                return View();
            }
        }

    }

}
