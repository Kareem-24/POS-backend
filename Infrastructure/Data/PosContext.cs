using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PosContext : IdentityDbContext<User>
    {
        public PosContext(DbContextOptions<PosContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
