using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Data;
using ListAsset.DataAccess.Models;
using Microsoft.Extensions.Logging;
using System;

namespace ListAsset.DataAccess.Repositories
{
    public class RepositoryCountry : IRepository<Country>
    {
        private readonly AssetDbContext _assetDbContext;
        private readonly ILogger _logger;

        public RepositoryCountry(ILogger<Country> logger)
        {
            _logger = logger;
        }

        public async Task<Country> Create(Country country)
        {
            try
            {
                if (country != null)
                {
                    var obj = _assetDbContext.Add<Country>(country);
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

        public void Delete(Country country)
        {
            try
            {
                if (country != null)
                {
                    var obj = _assetDbContext.Remove(country);
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

        public IEnumerable<Country> GetAll()
        {
            try
            {
                var obj = _assetDbContext.Countries.ToList();
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

        public Country GetById(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = _assetDbContext.Countries.FirstOrDefault(x => x.CountryId == Id);
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

        public void Update(Country country)
        {
            try
            {
                if (country != null)
                {
                    var obj = _assetDbContext.Update(country);
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
