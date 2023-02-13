using ListAsset.DataAccess.Models;
using ListAsset.ServerApp.Data.DB;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ListAsset.ServerApp.Data
{
    public class AssetServerService
    {
        ServerDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        private readonly ServerDbContext context;

        public AssetServerService(ServerDbContext context)
        {
            this.context = context;
        }

        public async Task<Asset> CreateAsset(Asset asset)
        {
            asset.AssetId = Guid.NewGuid();
            asset.CountryId = Guid.Parse("b76e578d-b989-41c6-a3e9-65c91f33d783");

            Context.Assets.Add(asset);
            Context.SaveChanges();

            return asset;
        }

        public List<Asset> GetAssets()
        {
            var items = Context.Assets.ToList();

            return items;
        }

        public Asset GetAssetByID(Guid id)
        {
            var items = Context.Assets.Where(x => x.AssetId == id).First();

            return items;
        }

        public async Task<Asset> DeleteAsset(Guid id)
        {
            var itemToDelete = Context.Assets
                              .Where(i => i.AssetId == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            Context.Assets.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            return itemToDelete;
        }

        public async Task<Asset> UpdateAsset(Asset asset)
        {
            var itemToUpdate = Context.Assets
                              .Where(i => i.AssetId == asset.AssetId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(asset);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            return asset;
        }
    }
}
