﻿using Expenses.Data.Access.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Access.DAL
{
    public class EFUnitOfWork : IUnitofWork
    {
        private  DbContext _context;
        public EFUnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }
        public DbContext Context => _context;
        public void Add<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Add(obj);
        }

        public void Attach<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Attach(obj);
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            return new DbTransaction(_context.Database.BeginTransaction(isolationLevel));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();  
        }

        public void Dispose()
        {

            _context = null;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Remove<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Remove(obj);
        }

        public void Update<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Update(obj);
        }
    }
}
