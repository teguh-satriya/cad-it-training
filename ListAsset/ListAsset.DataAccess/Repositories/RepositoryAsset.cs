using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Data;
using ListAsset.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ListAsset.DataAccess.Repositories
{
    public class RepositoryAsset : IRepository<Asset>
    {
        private readonly AssetDbContext _assetDbContext;

        AssetDbContext assetDbContext
        {
            get
            {
                return this._assetDbContext;
            }
        }

        public RepositoryAsset(AssetDbContext context)
        {
            this._assetDbContext= context;
        }

        public async Task<List<Asset>> GetAll()
        {
            try
            {
                var obj = await assetDbContext.Assets.ToListAsync();
                
                return obj;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Asset?> GetById(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = await assetDbContext.Assets.FirstOrDefaultAsync(x => x.AssetId == Id);
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

        public async Task<Asset> Create(Asset asset)
        {
            try
            {
                var obj = assetDbContext.Add<Asset>(asset);
                await assetDbContext.SaveChangesAsync();
                return obj.Entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Delete(Asset asset)
        {
            try
            {
                if (asset != null)
                {
                    var obj = assetDbContext.Remove(asset);
                    if (obj != null)
                    {
                        await assetDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Asset> Update(Asset asset)
        {
            try
            {
                var itemToUpdate = await assetDbContext.Assets
                                    .Where(i => i.AssetId == asset.AssetId)
                                    .FirstOrDefaultAsync();

                if (itemToUpdate == null)
                {
                    throw new Exception("Item not exist");
                }

                var entryToUpdate = assetDbContext.Entry(itemToUpdate);
                entryToUpdate.CurrentValues.SetValues(asset);
                entryToUpdate.State = EntityState.Modified;

                await assetDbContext.SaveChangesAsync();

                return asset;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
