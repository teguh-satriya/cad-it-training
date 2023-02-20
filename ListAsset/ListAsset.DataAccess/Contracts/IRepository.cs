using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAsset.DataAccess.Contracts
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);
        public void Delete(T _object);
        public Task<T> Update(T _object);
        public IQueryable<T> List();
        public Task<T?> Get(Guid? Id);
    }
}
