
using Agridoce.Domain.Interfaces;
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

        public bool Commit(IDbContextTransaction transaction = null)
        {
            return transaction == null ? 
                        _context.SaveChanges() > 0 : 
                        CommitDbContextTransaction(transaction);
        } 

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }

        private bool CommitDbContextTransaction(IDbContextTransaction transaction)
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

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
