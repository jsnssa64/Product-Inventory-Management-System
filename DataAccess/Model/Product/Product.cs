using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ProductBaseEntity : IValidatableObject
    {
        public bool Discontinued { get; set; } = false;
        public DateTime? DateOfDiscontinuedUTC { get; set; } = null;

        public void Discontinue()
        {
            this.Discontinued = true;
            this.DateOfDiscontinuedUTC = DateTime.UtcNow;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Discontinued)
                yield return new ValidationResult("Product Has been Discontinued.");
        }
    }

    public class Product : ProductBaseEntity
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


    public class ProductItem : ProductBaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal WeightPerUnit { get; set; }
        [Required]
        public string UnitName { get; set; }
        public int ItemsPerUnit { get; set; }
        public Product Product { get; set; }
        public InventoryItem Inventory { get; set; }
    }
}
