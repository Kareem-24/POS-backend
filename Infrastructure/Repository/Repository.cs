using Core.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PosContext _context;

        public Repository(PosContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task UpdateAsync(T entity) =>   _context.Set<T>().Update(entity);
        public async Task BulkUpdate(T entity) =>    _context.Set<T>().UpdateRange(entity);
        public async Task BulkInsert(T entity) =>    _context.Set<T>().AddRange(entity);
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null) _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> GetNextIdAsync()
        {
            var maxId = await _context.Set<T>().MaxAsync(e => (int?)EF.Property<int>(e, "ID")) ?? 0;
            return maxId + 1;
        }
    }
}
