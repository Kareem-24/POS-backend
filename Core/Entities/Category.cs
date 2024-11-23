using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category : EntityBase
    {
        public required string  Description { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<SubCategory>? SubCategories { get; set; } 


    }
}
