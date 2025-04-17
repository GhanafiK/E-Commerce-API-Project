using DomainLayer.Contracts;
using DomainLayer.Models;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string,object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var TypeName= typeof(TEntity).Name;
            if (_repositories.TryGetValue(TypeName,out object? value))
                return (IGenericRepository<TEntity,TKey>) value;

            else
            {
                var Repo = new GenericRepositoy<TEntity, TKey>(_dbContext);
                _repositories[TypeName]=Repo;
                return Repo;
            }
            
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
