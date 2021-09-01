using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class Principal : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}