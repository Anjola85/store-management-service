using InventoryManagementService.Data;
using InventoryManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementService.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailController : ControllerBase
{
    private readonly InventoryContext _context;

    public ProductDetailController(InventoryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetails()
    {
        return await _context.ProductDetails.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetail>> GetProductDetail(string id)
    {
        var productDetail = await _context.ProductDetails.FindAsync(id);

        if (productDetail == null)
        {
            return NotFound();
        }

        return productDetail;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
    {
        _context.ProductDetails.Add(productDetail);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductDetail), new { id = productDetail.Id }, productDetail);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductDetail(string id, ProductDetail productDetail)
    {
        if (id != productDetail.Id)
        {
            return BadRequest();
        }

        _context.Entry(productDetail).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ProductDetails.Any(e => e.Id == id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        var productDetail = await _context.ProductDetails.FindAsync(id);
        if (productDetail == null)
        {
            return NotFound();
        }

        _context.ProductDetails.Remove(productDetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
