using Expenses.Data.Access.DAL.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Access.DAL
{
    public class DbTransaction : ITransaction
    {
        private readonly IDbContextTransaction _efTransaction;
        public DbTransaction(IDbContextTransaction efTransaction)
        {
            _efTransaction = efTransaction;
        }
        public void Commit()
        {
            _efTransaction.Commit();
        }

        public void Dispose()
        {
            _efTransaction.Dispose();  
        }

        public void Rollback()
        {
            _efTransaction.Rollback();
        }
    }
}
