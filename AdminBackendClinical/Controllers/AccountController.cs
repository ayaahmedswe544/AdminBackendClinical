using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ApplicationUser.DTOs;
using ServiceLayer.ApplicationUser;

namespace AdminBackendClinical.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        public AccountController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto logindto)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Login info is not correct.");
                return View(logindto);
                 }
            var result= await _applicationUserService.LogInAsync(logindto);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                ModelState.AddModelError("", "Try again");
                return View(logindto);
            }
            return View(logindto);

        }
    }
}
