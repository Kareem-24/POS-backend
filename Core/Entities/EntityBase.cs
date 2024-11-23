using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int CreatedBy { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
