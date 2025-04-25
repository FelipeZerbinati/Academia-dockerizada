using Academia10.Domain.Interfaces.Postgres;
using Academia10.Domain.Models;

namespace Academia10.Domain.Interfaces.Repository;

public interface IUnitOfWork
{
    IRepositoryBase<Academia> Academia10Repository { get; }
    Task<bool> CommitAsync();
}
