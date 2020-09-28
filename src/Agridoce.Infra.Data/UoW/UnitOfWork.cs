using Agridoce.Domain.Core;
using Agridoce.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Agridoce.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgridoceContext _context;

        public UnitOfWork(AgridoceContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Commit(IDbContextTransaction transaction)
        {
            try
            {
                _context.SaveChanges();
                transaction.Commit();

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
