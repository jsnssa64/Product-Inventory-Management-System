using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductType_Brand> ProductTypeBrands { get; set; }
    }
}
