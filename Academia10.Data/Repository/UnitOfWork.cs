using Academia10.Data.Postgres.Context;
using Academia10.Data.Postgres.Repository;
using Academia10.Domain.Interfaces.Postgres;
using Academia10.Domain.Interfaces.Repository;
using Academia10.Domain.Models;

namespace Academia10.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    //contexts
    private readonly PostgresDbContext _postgresContext;
    //repositorys
    private IRepositoryBase<Academia>? _academiaRepository;
    public UnitOfWork(
PostgresDbContext postgresContext)
    {
        //constructor
        _postgresContext = postgresContext;
        //repositoryInject

    }

    //injections
    public IRepositoryBase<Academia> Academia10Repository => _academiaRepository ?? (_academiaRepository = new RepositoryBase<Academia>(_postgresContext));


    public async Task<bool> CommitAsync()
    {
        return await _postgresContext.SaveChangesAsync() > 0;
    }
}
