using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PetStore.AuthAPI.Data.DTO;
using PetStore.AuthAPI.Models;

namespace PetStore.AuthAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, IdentityUser<int>>();
        }
    }
}
