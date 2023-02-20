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

        public IQueryable<Country> ListCountries()
        {
            try
            {
                return _repository.List();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
