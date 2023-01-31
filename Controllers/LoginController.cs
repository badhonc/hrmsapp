using Microsoft.AspNetCore.Mvc;

namespace HRMSApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
