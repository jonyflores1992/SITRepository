using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.Controllers.API
{
    public class TrLecturaApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
