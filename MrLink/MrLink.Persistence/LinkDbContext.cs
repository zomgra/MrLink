using Microsoft.EntityFrameworkCore;
using MrLink.Application.Interfaces;
using MrLink.Domain;
using MrLink.Persistence.EntityTypeConfigurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MrLink.Persistence
{
    public class LinkDbContext : DbContext, ILinkDbContext
    {
        public DbSet<MLink> Links { get; set; }

        public LinkDbContext(DbContextOptions<LinkDbContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MLinkConfiguration());
            base.OnModelCreating(builder);
            builder.Entity<MLink>()
        .Property(b => b.Transitions)
        .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Dictionary<DateTime, int>>(v));
        }
    }
}
