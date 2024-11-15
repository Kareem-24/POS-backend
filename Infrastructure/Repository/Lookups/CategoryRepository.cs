using Core.Entities;
using Core.Models;
using Core.Repository.Lookups;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Lookups
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(PosContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllCatgoriesWithSubCategory()
        {
            return await _context.Category.Include(c => c.SubCategories).ToListAsync();

        }

        public async Task<Category> GetCatgoryWithSubCategory(int id)
        {
            return await _context.Category.Include(c => c.SubCategories).Where(c => c.ID == id).FirstOrDefaultAsync();
        }
    }
}
