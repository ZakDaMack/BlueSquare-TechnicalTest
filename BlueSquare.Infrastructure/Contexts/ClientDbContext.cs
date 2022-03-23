using BlueSquare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlueSquare.Infrastructure.Contexts
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        {

        }

        public DbSet<ClientJob> ClientJobs { get; set; }
    }
}
