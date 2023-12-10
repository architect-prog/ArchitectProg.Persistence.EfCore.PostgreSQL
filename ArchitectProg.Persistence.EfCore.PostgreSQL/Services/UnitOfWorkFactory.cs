using ArchitectProg.Kernel.Extensions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArchitectProg.Persistence.EfCore.PostgreSQL.Services;

public sealed class UnitOfWorkFactory(IServiceProvider provider) : IUnitOfWorkFactory
{
    public IUnitOfWork BeginTransaction()
    {
        var dbContext = provider.GetRequiredService<DbContext>();
        var result = new UnitOfWork(dbContext);
        return result;
    }
}