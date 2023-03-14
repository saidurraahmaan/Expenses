using Expenses.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Access.DAL
{
    public class MainDbContext:DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options):base(options){}


        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
