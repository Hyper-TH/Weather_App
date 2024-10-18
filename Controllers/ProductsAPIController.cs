using Microsoft.AspNetCore.Mvc;

namespace React_ASPNETCore.Controllers
{
    public class ProductsAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
