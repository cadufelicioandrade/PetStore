using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetStore.AuthAPI.Data.DbContext
{
    public class AuthContext(DbContextOptions<AuthContext> opt) : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>(opt)
    {
    }
}
