using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Models;

namespace ListAsset.BusinessAccess.Services
{
    public class CountryService
    {
        public readonly IRepository<Country> _repository;
        public CountryService(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<List<Country>> ListCountries()
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
