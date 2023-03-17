using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Access.DAL.Interface
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
