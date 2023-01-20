using AskMe.Domain.Application.Contracts.Persistence;
using AskMe.Domain.Entities.Common;
using AskMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseDomainEntity,new()
    {

        private readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
      
        }

        public async Task<bool> Exists(string id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public  async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
          
        }
    }
}
