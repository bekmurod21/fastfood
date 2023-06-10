using FastFood.Domain.Commons;
using System.Linq.Expressions;

namespace FastFood.Data.IRepositories
{
    public interface IRepository<TResult> where TResult : Auditable
    {
        ValueTask<TResult> InsertAsync(TResult value);
        ValueTask<TResult> UpdateAsync(TResult value);
        ValueTask<bool> DeleteAsync(Expression<Func<TResult,bool>> expression);
        bool DeleteManyAsync(Expression<Func<TResult, bool>> expression);
        ValueTask<TResult> SelectAsync(Expression<Func<TResult,bool>> expression, string[] includes = null);
        IQueryable<TResult> SelectAllAsync(Expression<Func<TResult,bool>> expression, string[] includes = null);
        ValueTask SaveChangesAsync();
    }
}
