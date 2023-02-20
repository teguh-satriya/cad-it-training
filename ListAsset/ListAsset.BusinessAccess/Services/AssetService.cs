using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Models;
using Radzen;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ListAsset.BusinessAccess.Services
{
    public class AssetService
    {
        public readonly IRepository<Asset> _repository;
        public AssetService(IRepository<Asset> repository)
        {
            _repository = repository;
        }

        public async Task<Asset?> GetAsset(Guid id)
        {
            var items = await _repository.Get(id);

            return items;
        }

        public async Task<Asset> CreateAsset(Asset asset)
        {
            asset.AssetId = Guid.NewGuid();

            await _repository.Create(asset);

            return asset;
        }

        public async Task<Asset> UpdateAsset(Asset? asset)
        {
            try
            {
                if(asset == null)
                    throw new Exception("Item not exist");

                await _repository.Update(asset);
            }
            catch
            {
                throw;
            }

            return asset;
        }

        public async Task<Asset> DeleteAsset(Guid id)
        {
            var itemToDelete = await _repository.Get(id);

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            try
            {
                _repository.Delete(itemToDelete);
            }
            catch
            {
                throw;
            }

            return itemToDelete;
        }

        public IQueryable<Asset> ListAssets(Query query = null)
        {
            try
            {
                var items = _repository.List();

                items = items.Include(i => i.Country);

                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.Expand))
                    {
                        var propertiesToExpand = query.Expand.Split(',');
                        foreach (var p in propertiesToExpand)
                        {
                            items = items.Include(p);
                        }
                    }

                    if (!string.IsNullOrEmpty(query.Filter))
                    {
                        if (query.FilterParameters != null)
                        {
                            items = items.Where(query.Filter, query.FilterParameters);
                        }
                        else
                        {
                            items = items.Where(query.Filter);
                        }
                    }

                    if (!string.IsNullOrEmpty(query.OrderBy))
                    {
                        items = items.OrderBy(query.OrderBy);
                    }

                    if (query.Skip.HasValue)
                    {
                        items = items.Skip(query.Skip.Value);
                    }

                    if (query.Top.HasValue)
                    {
                        items = items.Take(query.Top.Value);
                    }
                }


                return items;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
