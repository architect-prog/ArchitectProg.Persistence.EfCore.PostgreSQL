using ArchitectProg.Kernel.Extensions.Interfaces;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Repositories;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Services;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArchitectProg.Persistence.EfCore.PostgreSQL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEfCoreRepository(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));

        serviceCollection.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
        serviceCollection.AddScoped<IDatabaseMigrationApplier, DatabaseMigrationApplier>();
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

        return serviceCollection;
    }
}