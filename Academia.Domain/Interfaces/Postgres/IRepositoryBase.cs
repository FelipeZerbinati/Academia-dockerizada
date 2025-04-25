using Academia10.Domain.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Academia10.Domain.Interfaces.Postgres;

public interface IRepositoryBase<K>
where K : Base
{
    Task<K> GetAsync(bool tracking, Func<IQueryable<K>, IIncludableQueryable<K, object>>? include = null, Expression<Func<K, bool>>? predicate = null);
    Task<List<K>> GetAllAsync();
    Task<List<K>> GetFilteredAsync(bool tracking, Func<IQueryable<K>, IIncludableQueryable<K, object>>? include = null, Expression<Func<K, bool>>? predicate = null, Func<IQueryable<K>, IOrderedQueryable<K>>? orderBy = null, int? page = null, int? perPage = null);
    Task<bool> FindAsync(Expression<Func<K, bool>> expression);
    Task<long> CountAsync(Expression<Func<K, bool>> expression);
    Task<K?> GetByIdAsync(Guid id);
    Task<Guid> InsertAsync(K entity);
    Guid Insert(K entity);
    void Update(K entity);
    void Remove(K entity);
    void Delete(K entity);
}
