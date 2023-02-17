namespace ProductApp.ProductAppData.DataModel;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int CreatedBy { get; set; }
    public string? Category { get; set; }
}