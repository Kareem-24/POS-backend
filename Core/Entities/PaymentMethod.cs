using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PaymentMethod : EntityBase
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
