using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Model
{
    public  class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public User()
        {
            Roles = new List<UserRole>();
        }

    }
}
