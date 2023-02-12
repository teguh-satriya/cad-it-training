using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAsset.BusinessAccess.Services
{
    public class CountryService
    {
        public readonly IRepository<Country> _repository;
        public CountryService(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Country> GetAllUser()
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
