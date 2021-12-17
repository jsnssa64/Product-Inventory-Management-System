using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public int UnitsInStock { get; set; }
        public ProductItem ProductItem { get; set; }
        public bool Deactivated { get; set; } 
        //  CQRS - ES
        //public int AggregateId { get; set; }
        //public int Version { get; set; }
    }
}
