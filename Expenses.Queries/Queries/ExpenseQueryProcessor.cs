using Expenses.Api.Models.Expenses;
using Expenses.Data.Access.DAL.Interface;
using Expenses.Data.Model;
using Expenses.Queries.Queries.Interface;
using Expenses.Secuirity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Queries.Queries
{
    public class ExpenseQueryProcessor : IExpenseQueryProcessor
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ISecurityContext _securityContext;
        public ExpenseQueryProcessor(IUnitofWork unitofWork,ISecurityContext securityContext)
        {
            _unitofWork = unitofWork;
            _securityContext = securityContext;
        }
        public Task<Expense> Create(CreateExpenseModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Expense> Get()
        {
            throw new NotImplementedException();
        }

        public Expense GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> Update(int id, UpdateExpenseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
