using Core.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosContext _context;
        public UnitOfWork(PosContext context)
        {
            _context = context;
        }

        public IUserRepository Users => throw new NotImplementedException();

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
