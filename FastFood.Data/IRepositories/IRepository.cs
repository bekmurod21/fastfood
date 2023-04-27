using FastFood.Domain.Commons;
using System.Linq.Expressions;

namespace FastFood.Data.IRepositories
{
    public interface IRepository<TResult> where TResult:Auditable
    {
        ValueTask<TResult> CreateAsync(TResult value);
        ValueTask<TResult> UpdateAsync(TResult value,long id);
        ValueTask<bool> DeleteAsync(Expression<Func<TResult,bool>> expression);
        ValueTask<TResult> GetAsync(Expression<Func<TResult,bool>> expression);
        IQueryable<TResult> GetAllAsync();
    }
}
