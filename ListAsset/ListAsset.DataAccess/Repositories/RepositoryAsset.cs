using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Data;
using ListAsset.DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace ListAsset.DataAccess.Repositories
{
    public class RepositoryAsset : IRepository<Asset>
    {
        private readonly AssetDbContext _assetDbContext;
        private readonly ILogger _logger;

        public RepositoryAsset(ILogger<Asset> logger)
        {
            _logger = logger;
        }

        public async Task<Asset> Create(Asset asset)
        {
            try
            {
                if (asset != null)
                {
                    var obj = _assetDbContext.Add<Asset>(asset);
                    await _assetDbContext.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Asset asset)
        {
            try
            {
                if (asset != null)
                {
                    var obj = _assetDbContext.Remove(asset);
                    if (obj != null)
                    {
                        _assetDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Asset> GetAll()
        {
            try
            {
                var obj = _assetDbContext.Assets.ToList();
                if (obj != null)
                    return obj;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Asset GetById(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = _assetDbContext.Assets.FirstOrDefault(x => x.AssetId == Id);
                    if (Obj != null)
                        return Obj;
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Asset asset)
        {
            try
            {
                if (asset != null)
                {
                    var obj = _assetDbContext.Update(asset);
                    if (obj != null)
                        _assetDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
