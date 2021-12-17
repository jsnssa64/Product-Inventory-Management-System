using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.DTO.Product
{
    public class ProductItemBasicDTO
    {
        public string Name { get; set; }
        public ProductTypeDTO @Type { get; set; }
    }


    public class ProductItemDTO
    {
        public string Name { get; set; }
        public ProductDescriptionDTO Description { get; set; }
        public ProductTypeDTO @Type { get; set; }

        //  TO DO: Catergories Need To be added at some point
        //public List<ProductCatergoryTagDTO> Catergories { get; set; }

        public ProductItemDTO(string name, ProductDescriptionDTO description, ProductTypeDTO @type /*List<ProductCatergoryTagDTO> catergories*/)
        {
            Name = name;
            Description = description;
            @Type = @type;

            // Catergories = catergories;
        }
    }

    public class ProductDescriptionDTO {
        //  To Be Processed
        public int Id { get; set; }
        //  
        public string Description { get; set; }
    }


    public class ProductTypeDTO
    {
        //  To Be Processed
        public int Id { get; set; }

        //  Display
        public string Title { get; set; }
        public string @Type { get; set; }
        public string BrandName { get; set; }
    }

    public class ProductCatergoryTagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        ///     Use Existing Catergory
        /// </summary>
        /// <param name="id"></param>
        public ProductCatergoryTagDTO(int id)
        {
            Id = id;
        }

        /// <summary>
        ///     New Catergory
        /// </summary>
        /// <param name="name"></param>
        public ProductCatergoryTagDTO(string name)
        {
            Name = name;
        }
    }

}
