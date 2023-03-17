using Expenses.Api.Models.Expenses;
using Expenses.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Queries.Queries.Interface
{
    public interface IExpenseQueryProcessor
    {
        IQueryable<Expense> Get();
        Expense GetById(int id);
        Task<Expense> Create(CreateExpenseModel model);
        Task<Expense> Update(int id, UpdateExpenseModel model);
        Task Delete(int id);
    }
}
