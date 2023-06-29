namespace ArchitectProg.Persistence.EfCore.PostgreSQL.Services.Interfaces;

public interface IDatabaseMigrationApplier
{
    void ApplyMigrations();
}
