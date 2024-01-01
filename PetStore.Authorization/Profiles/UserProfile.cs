using AutoMapper;
using PetStore.Authorization.Data.DTO;
using PetStore.Authorization.Models;

namespace PetStore.Authorization.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<LoginUserDTO, User>();
        }
    }
}
