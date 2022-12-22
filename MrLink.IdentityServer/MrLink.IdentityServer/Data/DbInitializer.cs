using MrLink.IdentityServer.Models;

namespace MrLink.IdentityServer.Data
{
    public class DbInitializer
    {
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
            //context.Users.Add(new AppUser() { FirstName = "Filip", LastName = "Durov"});
        }
    }
}
