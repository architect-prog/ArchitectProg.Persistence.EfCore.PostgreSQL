using ArchitectProg.Kernel.Extensions.Interfaces;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Repositories;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Services;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Services.Interfaces;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArchitectProg.Persistence.EfCore.PostgreSQL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase<TContext>(
        this IServiceCollection serviceCollection,
        IConfigurationSection databaseSettings)
        where TContext : DbContext
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);

        serviceCollection.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
        serviceCollection.AddScoped<IDatabaseMigrationApplier, DatabaseMigrationApplier>();
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(NpgsqlRepository<>));

        serviceCollection.AddDbContext<DbContext, TContext>();

        serviceCollection.Configure<DatabaseSettings>(databaseSettings);

        return serviceCollection;
    }
}