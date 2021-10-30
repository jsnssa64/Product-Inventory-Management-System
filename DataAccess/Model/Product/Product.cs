using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductDescriptionId { get; set; }
        public int ProductTypesBrandId { get; set; }
        public int QuantityId { get; set; }
        public ProductDescription ProductDescription { get; set; }
        public ProductType_Brand ProductTypesBrand { get; set; }
        public Quantity Quantity { get; set; }
        public Inventory Inventory { get; set; }
    }

    public class ProductDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}
