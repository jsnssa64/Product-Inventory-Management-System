using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Migrations;
using Data.Model;
using System.Threading;
using StockAPI.DTO.Product;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using StockAPI.ApplicationModel;

namespace StockAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ProductService _productService;
        public ProductController(AppDbContext context, IMapper mapper, ProductService productService)
        {
            _context = context;
            _mapper = mapper;
            _productService = productService;
        }

        // GET: api/GetProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItemDTO>>> GetProducts(CancellationToken token)
        {
            return await _context.Products.ProjectTo<ProductItemDTO>(_mapper.ConfigurationProvider).ToListAsync(token);
            //return await _context.Products.AsAsyncEnumerable();
        }

        // GET: api/InventoryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItemDTO>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProductItemDTO>(product);
        }

        // PUT: api/InventoryItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductItemDTO product)
        {
            try
            {
                Data.Model.Product dbProduct = await _productService.Update(id, product);
                _context.Entry(dbProduct).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch(ApplicationException ex)
            {
                throw new ApplicationException("Update Failed: " + ex.Message); 
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductItemDTO>> PostProduct(ProductItemDTO product)
        {
            Data.Model.Product dbProduct = _mapper.Map<Data.Model.Product>(product);
            _context.Products.Add(dbProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = dbProduct.Id }, dbProduct);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbProduct = _productService.Delete(id);
                _context.Entry(dbProduct).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("Update Failed: " + ex.Message);
            }

            return NoContent();
        }


        private bool ProductExists(int id)
        {
            // If the product exists in the db and hasn't been discontinued
            return _context.Products.Any(e => e.Id == id && !e.Discontinued);
        }
    }
}
