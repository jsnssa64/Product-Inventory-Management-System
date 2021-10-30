using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    //  Value Object
    public class ProductType_Brand
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int BrandId { get; set; }
        public ProductType ProductType { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
