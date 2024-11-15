using Core.Repository;
using Core.Repository.Lookups;
using Infrastructure.Data;
using Infrastructure.Repository.Lookups;
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
        private IUserRepository _userRepository;
        private ICategoryRepository _Category;
        private ISubCategoryRepository _SubCategory;
        private IProductRepository _Product;

        public UnitOfWork(PosContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_Category == null)
                    _Category = new CategoryRepository(_context);
                return _Category;
            }
        }

        public ISubCategoryRepository SubCategory
        {
            get
            {
                if (_SubCategory == null)
                    _SubCategory = new SubCategoryRepository(_context);
                return _SubCategory;
            }
        }


        public IProductRepository Product
        {
            get
            {
                if (_Product == null)
                    _Product = new ProductRepository(_context);
                return _Product;
            }
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
