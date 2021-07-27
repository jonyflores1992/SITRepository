using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SIT.Models;

namespace SIT.Controllers
{

   public class DataGridController : BaseController
   {
        private UserContext _context;

		public DataGridController(UserContext Context)
		{
            this._context=Context;
		}

        public ActionResult Index()
        {

            ViewBag.dataSource = _context.Sector.ToList();

            retornarMainMenu();retornarUserMenuItems();return View();
        }

    }
}