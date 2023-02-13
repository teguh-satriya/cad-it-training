using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAsset.BusinessAccess.Services
{
    public class AssetService
    {
        public readonly IRepository<Asset> _repository;
        public AssetService(IRepository<Asset> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Asset> GetAll()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
