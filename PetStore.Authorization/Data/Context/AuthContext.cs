using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetStore.Authorization.Models;

namespace PetStore.Authorization.Data.Context
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext(DbContextOptions options): base(options){}
    }
}
