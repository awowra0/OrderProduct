using OrderProduct.Data;
using OrderProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrderProduct.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController: Controller
{
    private readonly OrderProductDbContext _context;

    public ProductController(OrderProductDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return Ok(await _context.Products.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.ProductId },
            product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(
        int id,
        Product product)
    {
        if (id != product.ProductId)
            return BadRequest();

        _context.Entry(product).State =
            EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}