namespace ArchitectProg.Persistence.EfCore.PostgreSQL.Interfaces;

public interface IDatabaseMigrationApplier
{
    void ApplyMigrations();
}
