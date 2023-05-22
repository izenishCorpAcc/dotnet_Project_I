using BulkyWeb_1._0.Models.DTO;
using BulkyWeb_1._0.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_1._0.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this._authService = authService;
        }
        
        public IActionResult Registration()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) 
                return View(model); 
            model.Role = "user";
            var result = await _authService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }






        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
       
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Reg()
        {
            var model = new RegistrationModel
            {
                Username = "superadmin",
                Name = "Jenish Prajapati",
                Email = "zenish77@gmail.com",
                Password = "i<3Nepal"
            };
            model.Role="admin";
            var result = await _authService.RegistrationAsync(model);
            return Ok(result);
        }
    }
}
