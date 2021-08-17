using Microsoft.AspNetCore.Mvc;

namespace CrowdyCloudBar.UserInterface.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
