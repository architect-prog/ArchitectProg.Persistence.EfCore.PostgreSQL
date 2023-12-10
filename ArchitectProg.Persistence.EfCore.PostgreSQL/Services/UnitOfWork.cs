using System.Data;
using ArchitectProg.Kernel.Extensions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ArchitectProg.Persistence.EfCore.PostgreSQL.Services;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly bool isNestedTransaction;
    private readonly IDbContextTransaction transaction;

    public UnitOfWork(DbContext context)
    {
        var currentTransaction = context.Database.CurrentTransaction;

        isNestedTransaction = currentTransaction is not null;
        transaction = currentTransaction ?? context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
    }

    public Task Commit()
    {
        return isNestedTransaction
            ? Task.CompletedTask
            : transaction.CommitAsync();
    }

    public Task Rollback()
    {
        return isNestedTransaction
            ? Task.CompletedTask
            : transaction.RollbackAsync();
    }

    public void Dispose()
    {
        if (isNestedTransaction)
            return;

        transaction.Dispose();
    }
}