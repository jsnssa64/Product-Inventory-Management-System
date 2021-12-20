using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Migrations;
using Data.Model;
using AutoMapper;
using Stock.Models;

namespace Stock.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
             var products = _context.Products
                                        .Include(p => p.ProductDescription)
                                        .Include(p => p.ProductTypesBrand.Brand)
                                        .Include(p => p.ProductTypesBrand.ProductType)
                                        .Include(p => p.ProductItems);

            return View(await _mapper.ProjectTo<BaseProductViewModel>(products).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductDescription)
                .Include(p => p.ProductTypesBrand.Brand)
                .Include(p => p.ProductTypesBrand.ProductType)
                .Include(p => p.ProductItems)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            DetailProductViewModel productview = _mapper.Map<DetailProductViewModel>(product);

            return View(productview);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProductDescriptionId"] = new SelectList(_context.ProductDescription, "Id", "Id");
            ViewData["ProductTypesBrandId"] = new SelectList(_context.ProductTypesBrand, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductDescriptionId,ProductTypesBrandId,Discontinued,DateOfDiscontinuedUTC")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductDescriptionId"] = new SelectList(_context.ProductDescription, "Id", "Id", product.ProductDescriptionId);
            ViewData["ProductTypesBrandId"] = new SelectList(_context.ProductTypesBrand, "Id", "Id", product.ProductTypesBrandId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductDescriptionId"] = new SelectList(_context.ProductDescription, "Id", "Id", product.ProductDescriptionId);
            ViewData["ProductTypesBrandId"] = new SelectList(_context.ProductTypesBrand, "Id", "Id", product.ProductTypesBrandId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductDescriptionId,ProductTypesBrandId,Discontinued,DateOfDiscontinuedUTC")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductDescriptionId"] = new SelectList(_context.ProductDescription, "Id", "Id", product.ProductDescriptionId);
            ViewData["ProductTypesBrandId"] = new SelectList(_context.ProductTypesBrand, "Id", "Id", product.ProductTypesBrandId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductDescription)
                .Include(p => p.ProductTypesBrand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
