using FastFood.Data.Contexts;
using FastFood.Data.IRepositories;
using FastFood.Domain.Commons;
using FastFood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace FastFood.Data.Repositories
{
    public class Repository<TResult> : IRepository<TResult> where TResult : Auditable
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<TResult> dbSet;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TResult>();
        }

        public async ValueTask<TResult> CreateAsync(TResult value)=>
            (await dbSet.AddAsync(value)).Entity;

        public async ValueTask<bool> DeleteAsync(Expression<Func<TResult, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            if (entity is null)
                return false;
            dbSet.Remove(entity);
            return true;
        }

        public IQueryable<TResult> GetAllAsync()
        => dbSet;

        public async ValueTask<TResult> GetAsync(Expression<Func<TResult, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }

        public async ValueTask SaveChangesAsync()
        =>  dbContext.SaveChanges();
        

        public async ValueTask<TResult> UpdateAsync(TResult value, long id)
        {
            value.Id = id;
            return dbSet.Update(value).Entity;
        }
    }
}
