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
        public async Task<Expense> Create(CreateExpenseModel model)
        {
            var item = new Expense
            {
                UserId = _securityContext.User.Id,
                Amount = model.Amount,
                Comment = model.Comment,
                Date = model.Date,
                Description = model.Description,
            };
            _unitofWork.Add(model);
            await _unitofWork.CommitAsync();
            return item;

        }

        public async Task Delete(int id)
        {
            var user = GetQuery().FirstOrDefault(x => x.Id == id);
            if(user== null)
            {
                throw new KeyNotFoundException("Expense is not found");
            }
            if (user.IsDeleted) return;
            user.IsDeleted = true;
            await _unitofWork.CommitAsync();
        }

        public IQueryable<Expense> Get()
        {
            var query = GetQuery();
            return query;
        }

        public IQueryable<Expense> GetQuery()
        {
            var q = _unitofWork.Query<Expense>()
                .Where(x => !x.IsDeleted);

            if (!_securityContext.IsAdministrator)
            {
                var userId = _securityContext.User.Id;
                q = q.Where(x => x.UserId == userId);    
            }
            return q;
        }

        public Expense GetById(int id)
        {
            var user = GetQuery().FirstOrDefault(x=>x.Id==id);
            if (user == null)
            {
                throw new KeyNotFoundException("Expense is not found");
            }
            return user;
        }

        public async Task<Expense> Update(int id, UpdateExpenseModel model)
        {
            var expense = GetQuery().FirstOrDefault(x => x.Id == id);
            if(expense == null) {
                throw new KeyNotFoundException("Expense is not found");
            }
            expense.Amount = model.Amount;
            expense.Comment = model.Comment;
            expense.Description = model.Description;
            expense.Date = model.Date;
            await _unitofWork.CommitAsync();
            return expense;
        }
    }
}
