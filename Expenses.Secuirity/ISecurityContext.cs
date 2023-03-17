using Expenses.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Secuirity
{
    public interface ISecurityContext
    {
        User User { get; }
        bool IsAdministrator { get;  }
    }
}
