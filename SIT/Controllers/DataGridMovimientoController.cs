using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SIT.Models;

namespace SIT.Controllers
{

   public class DataGridMovimientoController : Controller
   {
        private UserContext _context;

		public DataGridMovimientoController(UserContext Context)
		{
            this._context=Context;
		}

        public ActionResult Index()
        {

            ViewBag.dataSource = _context.Movimiento.ToList();

            return View();
        }

    }
}