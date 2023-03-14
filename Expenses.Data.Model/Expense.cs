using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Model
{
    public class Expense
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; } = String.Empty;
        public decimal Amount { get; set; }
        public string Comment { get; set; } = String.Empty ;

        public int UserId { get; set; }
        //public virtual User User { get; set; }

        public bool IsDeleted { get; set; }
    }
}
