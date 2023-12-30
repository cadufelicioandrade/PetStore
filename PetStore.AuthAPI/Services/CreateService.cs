using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using PetStore.AuthAPI.Data.DTO;
using PetStore.AuthAPI.Models;

namespace PetStore.AuthAPI.Services
{
    public class CreateService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CreateService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result Create(CreateUserDTO dto)
        {
            User user = _mapper.Map<User>(dto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            var resultIdentity = _userManager.CreateAsync(identityUser, dto.Password);

            if (resultIdentity.Result.Succeeded)
            {
                return Result.Ok().WithSuccess("Success creating user");
            }

            return Result.Fail("Unable to create user");
        }

    }
}
