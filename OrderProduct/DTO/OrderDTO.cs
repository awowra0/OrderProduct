namespace OrderProduct.DTO;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderGetItemDto> Products { get; set; } = [];
}

public class OrderGetItemDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description {get; set;} = string.Empty;
    public decimal Price { get; set; }
    public int Count { get; set; }
}

public class CreateOrderDto
{
    public List<OrderItemDto> Products { get; set; } = new List<OrderItemDto>();
}

public class UpdateOrderDto
{
    public List<OrderItemDto> Products { get; set; } = new();
}

public class OrderItemDto
{
    public int ProductId { get; set; }

    public int Count { get; set; }
}