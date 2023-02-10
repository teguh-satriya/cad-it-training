using ListAsset.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ListAsset.DataAccess.Data
{
    public class AssetDbContext:DbContext
    {
        public AssetDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
    }
}
