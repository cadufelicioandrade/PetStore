using Microsoft.AspNetCore.Mvc;
using PetStore.Web.DTO;

namespace PetStore.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UserDTO dto)
        {
            //Consumir o serviço AuthAPI:AuthController:Login
            return View();
        }

        public IActionResult Logout()
        {
            //Consumir o serviço AuthAPI:AuthController:Logout

            return SignOut();
        }

        public async Task<ActionResult> CreateUser()
        {
            return View();
        }

        public async Task<ActionResult> CreateUser([FromBody] UserDTO dto)
        {
            return View();
        }
    }
}
