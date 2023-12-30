using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PetStore.AuthAPI.Data.DTO;
using PetStore.AuthAPI.Data.Request;
using PetStore.AuthAPI.Services;

namespace PetStore.AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private LoginService _loginService;
        private LogoutService _logoutService;
        private CreateService _createService;

        public AuthController(LoginService loginService, LogoutService logoutService, CreateService createService)
        {
            _loginService = loginService;
            _logoutService = logoutService;
            _createService = createService;
        }

        [HttpPost]
        public IActionResult LoginUser(LoginRequest request)
        {
            Result result = _loginService.LoginUser(request);

            if (result.IsFailed)
                return Unauthorized(result.Errors[0].Message);

            return Ok(result.Successes[0].Message);
        }

        [HttpPost]
        public IActionResult LogoutUser()
        {
            Result result = _logoutService.LogoutUser();

            if (result.IsFailed)
                return Unauthorized(result.Errors[0].Message);

            return Ok(result.Successes[0].Message);

        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO dto)
        {
            Result result = _createService.Create(dto);

            if (result.IsFailed)
                return StatusCode(500);

            return Ok(result.Successes[0].Message);
        }
    }
}
