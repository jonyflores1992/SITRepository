using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIT.Models;
using System;
using System.Diagnostics;


namespace SIT.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }
        public IActionResult Index()
        {

            //Notify("Data saved successfully");
            //   BasicNotification("Could not delete data!", NotificationType.Success,"");

            retornarMainMenu(); retornarUserMenuItems(); retornarMainMenu(); retornarUserMenuItems(); return View();

//            return View();
        }

        public IActionResult Privacy()
        {
          //  return View();
           retornarMainMenu();retornarUserMenuItems();retornarMainMenu();retornarUserMenuItems();return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
  //          retornarMainMenu();retornarUserMenuItems();return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
