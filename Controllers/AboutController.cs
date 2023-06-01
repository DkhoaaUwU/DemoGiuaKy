using Microsoft.AspNetCore.Mvc;

namespace DemoGiuaKy.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
