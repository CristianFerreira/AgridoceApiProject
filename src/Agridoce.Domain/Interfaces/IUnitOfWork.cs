using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Agridoce.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit(IDbContextTransaction transaction = null);
        void Rollback(IDbContextTransaction transaction);
        IDbContextTransaction BeginTransaction();
    }
}
