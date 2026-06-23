namespace OrderProduct.Models;

public class Table
{
    public int OrderId {get; set;}
    public Order OrderInst {get; set;}
    public int ProductId {get; set;}
    public Product ProductInst {get; set;}
    public int Count {get; set;}
}