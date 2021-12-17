using Data.Migrations;
using Data.Model;
using StockAPI.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.ApplicationModel
{
    public class ProductTypeService
    {
        private readonly AppDbContext _context;
        public ProductTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductType> ChangeProductType(ProductTypeDTO pt)
        {
            if (pt.Id.Equals(0))
                throw new ArgumentNullException("No Existing Product Type was submitted.");
                
            //  Get Existing Product Type
            var dbProductType = await _context.ProductType.AsAsyncEnumerable().FirstOrDefaultAsync(x => x.Id == pt.Id);

            if (dbProductType == null)
                throw new Exception("Product Type Doesn't Exists");

            if(dbProductType.Title == pt.Type && dbProductType.Type == pt.Type)
                throw new Exception("No new values were submitted.");

            //  Check if value object already exists
            //  x.Equals(productType), does this include Id? Otherwise as this is a value object it must only compare values excluding Db Id
            bool newProductTypeAlreadyExists = _context.ProductType.Any(x => x.Title == pt.Title && x.Type == pt.Type);

            if (newProductTypeAlreadyExists)
                //  I do not want the application to do something outside of it's domain for example to loop through and
                //  change every brands product type, this must be modified indivudally.
                throw new Exception("Product Type Already Exists");

            //  Update Values
            dbProductType.Title = pt.Title;
            dbProductType.Type = pt.Type;

            return dbProductType;
        }

    }
}
