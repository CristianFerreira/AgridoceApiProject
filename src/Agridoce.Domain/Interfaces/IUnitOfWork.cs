using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Agridoce.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        bool Commit(IDbContextTransaction transaction);
        void Rollback(IDbContextTransaction transaction);
        IDbContextTransaction BeginTransaction();
    }
}
