using ListAsset.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ListAsset.ServerApp.Data.DB
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
