using Microsoft.EntityFrameworkCore;
using MrLink.Domain;

namespace MrLink.Application.Interfaces
{
    public interface ILinkDbContext
    {
        DbSet<MLink> Links { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
