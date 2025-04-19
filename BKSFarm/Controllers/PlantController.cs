using Microsoft.AspNetCore.Mvc;

namespace BKSFarm.api.Controllers
{
    public class PlantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
