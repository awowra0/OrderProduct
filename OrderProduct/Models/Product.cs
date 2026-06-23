namespace OrderProduct.Models;

public class Product
{
    public int ProductId {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;

    public decimal Price {get; set;}
    public ICollection<Table> OrderProducts { get; set; } = new List<Table>();
}