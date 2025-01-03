﻿using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Lookups
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCatgoryWithSubCategory(int id);
        Task<List<Category>> GetAllCatgoriesWithSubCategory();
    }
}
