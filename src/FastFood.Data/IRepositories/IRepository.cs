using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using FastFood.Domain.Commons;

namespace FastFood.Data.IRepositories
{
    public interface IRepository<TResult> where TResult : Auditable
    {
        ValueTask<TResult> InsertAsync(TResult value);
        ValueTask<TResult> UpdateAsync(TResult value);
        ValueTask<bool> DeleteAsync(Expression<Func<TResult, bool>> expression);
        ValueTask<bool> DeleteManyAsync(Expression<Func<TResult, bool>> expression);
        ValueTask<TResult> SelectAsync(Expression<Func<TResult, bool>> expression, string[] includes = null);
        IQueryable<TResult> SelectAllAsync(Expression<Func<TResult, bool>> expression = null, string[] includes = null);
    }
}
