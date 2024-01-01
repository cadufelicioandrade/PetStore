using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetStore.Authorization.Data.DTO;
using PetStore.Authorization.Models;
using PetStore.Authorization.Services;

namespace PetStore.Authorization.Controllers
{
    [ApiController]
    [Route("authorization/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        
        private UserServices _userServices;

        public AuthorizationController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO dto)
        {
            var result = await _userServices.CreateUser(dto, Enums.Roles.client);

            if (result.Succeeded)
                return Ok();

            return BadRequest("Unable to create user");        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserDTO dto)
        {
            string token = await _userServices.Login(dto);

            if (String.IsNullOrEmpty(token))
                return BadRequest("Unable to login user");

            return Ok(token);
        }
    }
}
