using AutoMapper;
using Data.Migrations;
using Data.Model;
using StockAPI.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.ApplicationModel
{
    public class BrandService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BrandService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Brand> Update(BasicBrandDTO branddto)
        {
            //  TODO: Check if Equals BrandDTO works ignoring the Id field??
            var dbBrand = await _context.Brands.AsAsyncEnumerable().FirstOrDefaultAsync(x => x.Equals(branddto));

            if (dbBrand != null)
                throw new Exception("Brand Already Exists");

            //  Update Values
            dbBrand = _mapper.Map<Brand>(branddto);
            return dbBrand;
        }
    }
}
