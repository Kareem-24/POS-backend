using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }
        public required string Description { get; set; }
        public List<SubCategoryModel>? SubCategory { get; set; } = new List<SubCategoryModel>();
    }


  
}
