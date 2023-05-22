using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_1._0.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
