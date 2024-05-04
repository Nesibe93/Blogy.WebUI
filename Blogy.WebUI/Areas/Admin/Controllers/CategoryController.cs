using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Admin")]
        [Route("Admin/Category")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
