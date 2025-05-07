using Microsoft.AspNetCore.Mvc;

namespace PROG7311_ST10375622_part2.Controllers
{
    public class ResourcesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
