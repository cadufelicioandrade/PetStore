using Microsoft.AspNetCore.Mvc;
using PetStore.Web.Models;
using PetStore.Web.Services;
using PetStore.Web.Services.Interfaces;
using System.Diagnostics;

namespace PetStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(AuthModel authModel)
        {
            var token = await _authService.LoginUser(authModel);
            SalveToken(token);

            return RedirectToAction(nameof(Index));
        }

        private void SalveToken(string token)
        {
            HttpContext.Request.Headers["access_token"] = token;
            HttpContext.Response.Headers["access_token"] = token;
        }
    }
}
