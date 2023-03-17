using Expenses.Data.Access.DAL.Interface;
using Expenses.Data.Model;
using Expenses.Queries.Queries;
using Expenses.Queries.Queries.Interface;
using Expenses.Secuirity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Queries.Tests
{
    public class ExpensesQueryProcessorTests
    {
        private Mock<IUnitofWork> _uow;
        private List<Expense> _expenseList;
        private IExpenseQueryProcessor _query;
        private Random _random;
        private User _user;
        private Mock<ISecurityContext> _securityContext;

        public ExpensesQueryProcessorTests()
        {
            _random = new Random();
            _uow = new Mock<IUnitofWork>();
            _expenseList = new List<Expense>(); 
            _uow.Setup(x=>x.Query<Expense>()).Returns(()=>_expenseList.AsQueryable());
            _user = new User { Id = _random.Next() };
            _securityContext = new Mock<ISecurityContext>(MockBehavior.Strict);
            _securityContext.Setup(x => x.User).Returns(_user);
            _securityContext.Setup(x=>x.IsAdministrator).Returns(false);

            _query = new ExpenseQueryProcessor(_uow.Object, _securityContext.Object);
        }

    }
}
