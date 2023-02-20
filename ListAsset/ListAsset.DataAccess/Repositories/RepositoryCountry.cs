using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Data;
using ListAsset.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ListAsset.DataAccess.Repositories
{
    public class RepositoryCountry : IRepository<Country>
    {
        private readonly AssetDbContext _assetDbContext;

        AssetDbContext assetDbContext
        {
            get
            {
                return this._assetDbContext;
            }
        }

        public RepositoryCountry(AssetDbContext context)
        {
            this._assetDbContext = context;
        }

        public IQueryable<Country> List()
        {
            try
            {
                var obj = assetDbContext.Countries;

                return obj;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Country?> Get(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = await assetDbContext.Countries.FirstOrDefaultAsync(x => x.CountryId == Id);
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

        public async Task<Country> Create(Country country)
        {
            try
            {
                var obj = assetDbContext.Add(country);
                await assetDbContext.SaveChangesAsync();
                return obj.Entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Delete(Country country)
        {
            try
            {
                if (country != null)
                {
                    var obj = assetDbContext.Remove(country);
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

        public async Task<Country> Update(Country country)
        {
            try
            {
                var itemToUpdate = await assetDbContext.Countries
                                    .Where(i => i.CountryId == country.CountryId)
                                    .FirstOrDefaultAsync();

                if (itemToUpdate == null)
                {
                    throw new Exception("Item not exist");
                }

                var entryToUpdate = assetDbContext.Entry(itemToUpdate);
                entryToUpdate.CurrentValues.SetValues(country);
                entryToUpdate.State = EntityState.Modified;

                await assetDbContext.SaveChangesAsync();

                return country;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
