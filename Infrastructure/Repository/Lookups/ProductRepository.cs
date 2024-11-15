using Core.Entities;
using Core.Repository.Lookups;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Lookups
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(PosContext context) : base(context)
        {
        }
    }
}
