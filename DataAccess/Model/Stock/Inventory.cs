using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public int UnitsInStock { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}
