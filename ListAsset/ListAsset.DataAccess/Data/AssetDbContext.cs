using ListAsset.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ListAsset.DataAccess.Data
{
    public class AssetDbContext:DbContext
    {
        public AssetDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Asset> Assets { get; set; }
        DbSet<Country> Countries { get; set; }
    }
}
