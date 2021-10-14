using Microsoft.AspNetCore.Mvc;

namespace Tec.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}