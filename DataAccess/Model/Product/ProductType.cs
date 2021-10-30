using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<ProductType_Brand> ProductTypesBrand { get; set; }
    }
}
