using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Models;

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
            var items = await _repository.GetById(id);

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
            var itemToDelete = await _repository.GetById(id);

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

        public async Task<List<Asset>> ListAssets()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
