using Azure;
using Microsoft.AspNetCore.Mvc;
using React_ASPNETCore.Models;
using React_ASPNETCore.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace React_ASPNETCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsFirestoreController : ControllerBase
    {
        private readonly FirestoreService _firestoreService;

        public ProductsFirestoreController(FirestoreService firestoreService) 
        { 
            _firestoreService = firestoreService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await _firestoreService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _firestoreService.GetAllProductsAsync();
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // Full update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, ProductDocument updatedProduct)
        {
            updatedProduct.ID = id.GetHashCode();
            await _firestoreService.UpdateProductAsync(id, updatedProduct);

            return NoContent(); // 204 on successful update
        }

        // Partial Update
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductPartial(string id, JsonPatchDocument<ProductDocument> patchDoc)
        {
            var product = await _firestoreService.GetProductAsync(id);
            if (product == null) return NotFound();

            patchDoc.ApplyTo(product);
            await _firestoreService.UpdateProductAsync(id, product);

            return NoContent();
        }
    }
}
