using AutoMapper;
using Data.Migrations;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using StockAPI.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.ApplicationModel
{

    public class ProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private async Task<ProductDescription> HandleDescription(ProductDescriptionDTO dto)
        {
            ProductDescription descriptionobj = null;

            //  Existing Description
            if (dto.Id > 0)
            {
                if (!_context.ProductDescription.Any(x => x.Id == dto.Id))
                    throw new ArgumentException("Product Description Not Found.");

                //dbProductItem.ProductDescription.Id = id;
                descriptionobj = new ProductDescription() { Id = (int)dto.Id };
            }
            //  New Description
            else
            {
                //  Prevent Duplicates
                descriptionobj = await _context.ProductDescription.AsAsyncEnumerable().FirstOrDefaultAsync(x => x.Description.Equals(dto.Description, StringComparison.OrdinalIgnoreCase));
            }

            return (descriptionobj == null) ? _mapper.Map<ProductDescription>(dto.Description) : descriptionobj;
        }

        public async Task<Product> Update(int id, ProductItemDTO productItemDTO)
        {
            var dbProductItem = await _context.Products.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            if (dbProductItem == null)
                throw new Exception("Product Doesn't Exist");

            //  TODO: Check if Description Uses Existing Description
            if(productItemDTO.Description.Id != dbProductItem.ProductDescription.Id)
                dbProductItem.ProductDescription = await HandleDescription(productItemDTO.Description);


            if (!_context.ProductTypesBrand.Any(x => x.Id == productItemDTO.Type.Id))
                throw new ArgumentException("Product Type Not Found.");

            dbProductItem.ProductTypesBrandId = (int)productItemDTO.Type.Id;
            dbProductItem.Name = productItemDTO.Name;

            return dbProductItem;
        }

        public async Task<Product> Delete(int id) {
            Product dbProduct = await _context.Products.AsQueryable().Include(p => p.ProductItems).FirstOrDefaultAsync(x => x.Id == id);

            if (dbProduct == null)
                throw new Exception("Product Not Found.");

            dbProduct.Discontinue();

            await foreach (var item in dbProduct.ProductItems.ToAsyncEnumerable())
                item.Discontinue();
            
            return dbProduct;
        }

    }
}
