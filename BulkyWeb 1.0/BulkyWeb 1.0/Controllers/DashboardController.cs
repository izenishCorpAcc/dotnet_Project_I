using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_1._0.Controllers
{
    [Authorize]

    public class DashboardController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
