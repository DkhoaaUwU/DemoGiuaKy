using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DemoGiuaKy.Controllers
{
	public class AdminController : Controller
	{
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
		{
			return View();
		}
	}
}
