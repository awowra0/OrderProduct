using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProduct.Data;
using OrderProduct.Models;
using OrderProduct.DTO;

namespace OrderProduct.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly OrderProductDbContext _context;

    public OrderController(OrderProductDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _context.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.ProductInst)
            .ToListAsync();
        
        return Ok(orders);
    }

    [HttpGet("{id}")]
     public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.ProductInst)
            .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]
     public async Task<ActionResult<Order>> CreateOrder(
        CreateOrderDto dto)
    {
        var order = new Order();

        foreach (var item in dto.Products)
        {
            order.OrderProducts.Add(new Table
            {
                ProductId = item.ProductId,
                Count = item.Count
            });
        }

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return Created(
            nameof(GetOrder),
            order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(
        int id,
        UpdateOrderDto dto)
    {
        var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null)
            return NotFound();

        var existingItems = order.OrderProducts.ToList();

        foreach (var item in dto.Products)
        {
            var existing = existingItems
                .FirstOrDefault(x => x.ProductId == item.ProductId);

            if (existing != null)
            {
                existing.Count = item.Count;
            }
            else
            {
                order.OrderProducts.Add(new Table
                {
                    ProductId = item.ProductId,
                    Count = item.Count
                });
            }
        }

        var productsToRemove = existingItems
            .Where(x => !dto.Products
                .Any(p => p.ProductId == x.ProductId));

        _context.Table.RemoveRange(productsToRemove);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
            return NotFound();

        _context.Orders.Remove(order);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}