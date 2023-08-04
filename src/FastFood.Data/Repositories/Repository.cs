using FastFood.Data.Contexts;
using System.Linq.Expressions;
using FastFood.Domain.Commons;
using FastFood.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

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

        public async ValueTask<TResult> InsertAsync(TResult value)
        {
            var entity = (await dbSet.AddAsync(value)).Entity;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<TResult, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            if (entity is null)
            {
                return false;
            }
            entity.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            return true;
        }
        public IQueryable<TResult> SelectAllAsync(Expression<Func<TResult,bool>> expression = null, string[] includes = null)
        {
            IQueryable<TResult> query = expression is null ? this.dbSet : this.dbSet.Where(expression);

            if (includes is not null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public async ValueTask<TResult> SelectAsync(Expression<Func<TResult, bool>> expression, string[] includes = null)
        => await this.SelectAllAsync(expression, includes).FirstOrDefaultAsync(t => !t.IsDeleted);


        public async ValueTask<TResult> UpdateAsync(TResult value)
        {
            var entity = this.dbSet.Update(value).Entity;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async ValueTask<bool> DeleteManyAsync(Expression<Func<TResult, bool>> expression)
        {
            var entities = this.dbSet.Where(expression);
            if(entities.Any())
            {
                foreach(var entity in entities)
                    entity.IsDeleted = true;
                return true;
            }
            await dbContext.SaveChangesAsync();
            return false;
        }
    }
}
