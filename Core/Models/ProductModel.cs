using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        public int CategoryId { get; set; }
        public required string Description { get; set; }
        public required string Code { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string? Barcode { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
    }
}
