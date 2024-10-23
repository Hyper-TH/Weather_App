using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using React_ASPNETCore.Data;
using React_ASPNETCore.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace React_ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        // The database context to interact with the Product db
        private readonly ProductDbContext _context;

        // Constructor that injects the database context via dependency injection
        public ProductsAPIController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(_context.Product.ToList());   // Note: Synchronous in EF6
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            product.ID = 0; // Ensure to not insert an explicit value;

            _context.Product.Add(product);      // Add new product to db context
            await _context.SaveChangesAsync();  // Save changes asynchronously to persist new prod to database

            return CreatedAtAction(
                nameof(CreateProduct), new { id = product.ID }, product);    // References GetProduct
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest("Product ID mismatch.");
            }

            // Mark prod entity as modified in the context
            _context.Entry(product).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            // Handles concurrenct exception
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Product.Any(e => e.ID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
