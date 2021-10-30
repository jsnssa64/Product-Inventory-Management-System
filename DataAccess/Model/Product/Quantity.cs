using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Quantity
    {
        public int QuantityId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal WeightPerUnit { get; set; }
        public int ItemsPerUnit { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
