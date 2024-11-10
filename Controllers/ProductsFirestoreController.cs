using Azure;
using Microsoft.AspNetCore.Mvc;
using React_ASPNETCore.Models;
using React_ASPNETCore.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.CodeAnalysis;

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

        // GET /api/products/{productID}
        [HttpGet("{productID:int}")]
        public async Task<IActionResult> GetProduct(int productID)
        {
            var product = await _firestoreService.GetProductAsync(productID);
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

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDocument newProduct)
        {
            if (newProduct == null || newProduct.ProductID <= 0)
            {
                return BadRequest("Invalid product data");
            }

            try
            {
                await _firestoreService.AddProductAsync(newProduct);

                // 201 response
                return CreatedAtAction(nameof(GetProduct), new { productID = newProduct.ProductID }, newProduct);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //// Full update
        //[HttpPut("{productID:int}")]
        //public async Task<IActionResult> UpdateProduct(int productID, ProductDocument updatedProduct)
        //{
        //    updatedProduct.ProductID = productID.GetHashCode();
        //    await _firestoreService.UpdateProductAsync(productID, updatedProduct);

        //    return NoContent(); // 204 on successful update
        //}

        //// Partial Update
        //[HttpPatch("{productID:int}")]
        //public async Task<IActionResult> UpdateProductPartial(int productID, JsonPatchDocument<ProductDocument> patchDoc)
        //{
        //    var product = await _firestoreService.GetProductAsync(productID);
        //    if (product == null) return NotFound();

        //    patchDoc.ApplyTo(product);
        //    await _firestoreService.UpdateProductAsync(productID, product);

        //    return NoContent();
        //}
    }
}
