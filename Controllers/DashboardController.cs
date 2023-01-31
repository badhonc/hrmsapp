using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
