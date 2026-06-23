namespace OrderProduct.DTO;

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