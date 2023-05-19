using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_1._0.Controllers
{
    
    public class RolemanagerController:Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolemanagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //List all the roles created by users
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //avoid duplicate roles
            if(!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
