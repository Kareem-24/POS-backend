﻿using Core.Repository.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; } 
        IProductRepository Product { get; }
        Task<int> CompleteAsync();
    }
}
