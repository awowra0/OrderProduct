namespace OrderProduct.Models;

public class Order
{
    public int OrderId {get; set;}
    public DateTime CreatedDate {get; set;} = DateTime.UtcNow;
    public ICollection<OPTable> OrderProducts { get; set; } = new List<OPTable>();
}