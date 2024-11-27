using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order:EntityBase
    {
        public string UserId {get; set;}
        [ForeignKey("UserId")]
        public User User { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }

        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public PaymentMethod paymentMethod { get; set; }
    }
}
