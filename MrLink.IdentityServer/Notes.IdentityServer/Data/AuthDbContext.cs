using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MrLink.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrLink.IdentityServer.Data
{
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(e => e.ToTable(name:"Users"));
            builder.Entity<IdentityUser>(e => e.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(e => e.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(e => e.ToTable(name: "UserClaims"));
            builder.Entity<IdentityUserLogin<string>>(e =>
                e.ToTable("UserLogins"));
            builder.Entity<IdentityUserToken<string>>(e =>
                e.ToTable("UserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(e =>
                e.ToTable("RoleClaims"));  
            builder.ApplyConfiguration(new AppUserConfiguration());
            //  base.OnModelCreating(builder);
        }
    }
}
