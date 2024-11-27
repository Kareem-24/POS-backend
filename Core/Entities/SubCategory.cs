using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SubCategory: EntityBase
    {
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public required Category Category { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
