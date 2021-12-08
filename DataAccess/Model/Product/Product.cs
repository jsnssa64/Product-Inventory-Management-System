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
        public ProductDescription ProductDescription { get; set; }
        public ProductType_Brand ProductTypesBrand { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
    }

    public class ProductDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }


    public class ProductItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal WeightPerUnit { get; set; }
        public int ItemsPerUnit { get; set; }
        public Product Product { get; set; }
        public InventoryItem Inventory { get; set; }
    }
}
